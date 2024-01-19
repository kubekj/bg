import React from "react";
import {useFormik} from "formik";
import * as yup from "yup";
import Link from "next/link";
import {useRouter} from "next/router";
import {useSession} from "next-auth/react";
import {poster, putter} from "../../../lib/rest-api";

import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import {Button, InputLabel, MenuItem, Select, TextField} from "@mui/material";
import CustomButton from "../../reusable/button";

const bodyParts = ["Legs", "Arms", "Chest", "Shoulders", "Core"];
const categories = ["Upper", "Lower", "Full", "Cardio"];

const validationSchema = yup.object().shape({
    name: yup.string().required("Please provide a name for exercise"),
    bodyPart: yup
        .string()
        .required("Please choose the body part meant for this exercise"),
    category: yup
        .string()
        .required("Please choose the category of this exercise"),
});

function ExerciseModal(props) {
    const router = useRouter();
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    const {data} = useSession();
    const {
        exercise,
        isDetails,
        icon,
        backgroundColorValue,
        isHoveringColor,
        text,
        extraStyleType,
        extraStyleValue,
    } = props;

    const formik = useFormik({
        initialValues: {
            name: exercise ? exercise.name : "",
            bodyPart: exercise ? exercise.bodyPart : "",
            category: exercise ? exercise.category : "",
        },
        validationSchema: validationSchema,
        onSubmit: async (values) => {
            if (exercise) {
                await putter(`exercises/${exercise.id}`, values, data.jwt);
            } else {
                await poster("exercises/create", values, data.jwt);
                formik.handleReset();
            }
            router.replace("/athlete/exercise");
            handleClose();
        },
    });

    const title = !exercise ? "Add new exercise" : "Exercise details";
    const btnlabel = !exercise ? "Add" : "Edit";

    return (
        <>
            <CustomButton
                iconSrc={icon}
                text={text}
                backgroundColorValue={backgroundColorValue}
                borderValue='none'
                isHoveringColor={isHoveringColor}
                extraStyleType={extraStyleType}
                extraStyleValue={extraStyleValue}
                onClick={handleOpen}
            />
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby='modal-modal-title'
                aria-describedby='modal-modal-description'
            >
                <form
                    onSubmit={formik.handleSubmit}
                    className='relative top-1/4 mx-auto flex flex-col items-center bg-white w-1/3 rounded-xl'
                >
                    <div className='flex flex-col isolate w-full bg-gray-200 p-10 rounded-t-xl'>
                        <div className='flex flex-row place-content-between w-full'>
                            <Typography id='modal-modal-title' variant='h6' component='h2'>
                                {title}
                            </Typography>
                            <Link href={""} className='no-underline text-gray-800'>
                                <Typography
                                    id='modal-modal-title'
                                    variant='h6'
                                    component='h2'
                                    onClick={handleClose}
                                >
                                    x
                                </Typography>
                            </Link>
                        </div>
                        <Typography
                            id='modal-modal-description'
                            className='text-gray-600'
                            sx={{mt: 1}}
                        >
                            Provide details
                        </Typography>
                    </div>
                    <div className='flex flex-col items-start p-10 gap-5 w-full'>
                        <div className='flex flex-col justify-center gap-3 w-full'>
                            <InputLabel>Name</InputLabel>
                            <TextField
                                name='name'
                                value={formik.values.name}
                                error={formik.touched.name && Boolean(formik.errors.name)}
                                className={`${
                                    formik.touched.name && formik.errors.name
                                        ? "border-red-500"
                                        : ""
                                }`}
                                onChange={formik.handleChange}
                                disabled={isDetails}
                            ></TextField>
                            {formik.touched.name && formik.errors.name && (
                                <span className='text-red-500'>{formik.errors.name}</span>
                            )}
                            <InputLabel>Body Part</InputLabel>
                            <Select
                                name='bodyPart'
                                value={formik.values.bodyPart}
                                error={
                                    formik.touched.bodyPart && Boolean(formik.errors.bodyPart)
                                }
                                className={`${
                                    formik.touched.bodyPart && formik.errors.bodyPart
                                        ? "border-red-500"
                                        : ""
                                }`}
                                onChange={formik.handleChange}
                                disabled={isDetails}
                            >
                                {bodyParts.map((bodyPart) => {
                                    return (
                                        <MenuItem key={bodyPart} value={bodyPart}>
                                            {bodyPart}
                                        </MenuItem>
                                    );
                                })}
                            </Select>
                            {formik.touched.bodyPart && formik.errors.bodyPart && (
                                <span className='text-red-500'>{formik.errors.bodyPart}</span>
                            )}
                            <InputLabel>Category</InputLabel>
                            <Select
                                name='category'
                                value={formik.values.category}
                                error={
                                    formik.touched.category && Boolean(formik.errors.category)
                                }
                                className={`${
                                    formik.touched.category && formik.errors.category
                                        ? "border-red-500"
                                        : ""
                                }`}
                                onChange={formik.handleChange}
                                disabled={isDetails}
                            >
                                {categories.map((category) => {
                                    return (
                                        <MenuItem key={category} value={category}>
                                            {category}
                                        </MenuItem>
                                    );
                                })}
                            </Select>
                            {formik.touched.category && formik.errors.category && (
                                <span className='text-red-500'>{formik.errors.category}</span>
                            )}
                        </div>
                    </div>

                    <div className='flex flex-col px-8 py-2 w-full items-center'>
                        <div className='flex flex-row w-full gap-3 py-6'>
                            <Button
                                style={{
                                    backgroundColor: "#D0D5DD",
                                    color: "#000000",
                                    borderRadius: 10,
                                    border: "none",
                                }}
                                variant='outlined'
                                onClick={() => {
                                    formik.handleReset();
                                    handleClose();
                                }}
                                className={isDetails ? "w-full" : "w-1/2"}
                            >
                                {isDetails ? "Close" : "Cancel"}
                            </Button>
                            {!isDetails && (
                                <Button
                                    style={{
                                        backgroundColor: "#8098F9",
                                        borderRadius: 10,
                                    }}
                                    variant='contained'
                                    type='submit'
                                    className='w-1/2'
                                >
                                    {btnlabel}
                                </Button>
                            )}
                        </div>
                    </div>
                </form>
            </Modal>
        </>
    );
}

export default ExerciseModal;
