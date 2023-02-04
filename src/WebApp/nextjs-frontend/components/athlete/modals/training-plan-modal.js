import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import Link from "next/link";
import { useRouter } from "next/router";
import { useSession } from "next-auth/react";
import { poster, putter } from "../../../lib/rest-api";

import Typography from "@mui/material/Typography";
import {
  Button,
  Dialog,
  Grid,
  InputLabel,
  MenuItem,
  TextField,
} from "@mui/material";
import CustomButton from "../../reusable/button";
import { Select } from "@mui/material";
import { Stack } from "@mui/system";

const statuses = ["Active", "Unpublished", "Published"];
const noOfExercieses = [1, 2, 3, 4, 5, 6, 7];
const basePlan = { id: "" };

const validationSchema = yup.object().shape({
  title: yup.string().required("Please provide a title for plan"),
  description: yup
    .string()
    .required("Please choose the category of this workout"),
  plans: yup.array().of(
    yup.object().shape({
      id: yup.string().required("Training is required"),
    })
  ),
  weeks: yup.number().required("Please mark how long will the training last"),
  price: yup.number().required("Please provide the price of given plan"),
  language: yup
    .string()
    .required("Please provide the language in which the plan is written"),
  skillLevel: yup.string().required("Please provide the skill level"),
  status: yup
    .string()
    .required(
      "Please provide an info of what the status of this plan should be"
    ),
  noOfPlans: yup
    .number()
    .required("Mark how many workouts will the plan contain"),
});

function TrainingPlanModal(props) {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const { data } = useSession();
  const router = useRouter();

  const formik = useFormik({
    initialValues: {
      title: "",
      description: "",
      plans: [],
      weeks: "",
      price: "",
      language: "",
      skillLevel: "",
      status: "",
      noOfPlans: 1,
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {},
  });

  function onChangeWorkouts(e) {
    // update dynamic form
    const plans = formik.values.plans;
    const numberOfPlans = e.target.value || 0;
    const previousNumber = parseInt(formik.values.noOfPlans || "0");
    if (previousNumber < numberOfPlans) {
      for (let i = previousNumber; i < numberOfPlans; i++) {
        plans.push({ id: "" });
      }
    } else {
      for (let i = previousNumber; i >= numberOfPlans; i--) {
        plans.splice(i, 1);
      }
    }
    formik.setFieldValue("plans", plans);
    // call formik onChange method
    formik.setFieldValue("noOfPlans", e.target.value);
  }

  const title = !props.workout ? "Create new plan" : "Plan details";
  const btnlabel = !props.workout ? "Add" : "Edit";

  return (
    <>
      <CustomButton
        iconSrc={props.icon}
        text={props.text}
        backgroundColorValue={props.backgroundColorValue}
        borderValue='none'
        isHoveringColor={props.isHoveringColor}
        extraStyleType={props.extraStyleType}
        extraStyleValue={props.extraStyleValue}
        onClick={handleOpen}
      />
      <Dialog
        open={open}
        onClose={handleClose}
        className={
          ({ overflow: "scroll" }, "h-screen flex justify-center items-center")
        }
      >
        <form
          onSubmit={formik.handleSubmit}
          className='relative mx-auto flex flex-col items-center bg-white rounded-xl w-full'
        >
          <div className='flex flex-col isolate w-full bg-gray-200 p-10 '>
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
              sx={{ mt: 1 }}
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
                placeholder='eg. Push'
                error={formik.touched.name && Boolean(formik.errors.name)}
                className={`${
                  formik.touched.name && formik.errors.name
                    ? "border-red-500"
                    : ""
                }`}
                onChange={formik.handleChange}
                // disabled={isDetails}
              ></TextField>
              {formik.touched.name && formik.errors.name && (
                <span className='text-red-500'>{formik.errors.name}</span>
              )}
              <InputLabel>Description</InputLabel>
              <TextField
                name='description'
                multiline
                rows={4}
                value={formik.values.description}
                error={
                  formik.touched.description &&
                  Boolean(formik.errors.description)
                }
                className={`${
                  formik.touched.description && formik.errors.description
                    ? "border-red-500"
                    : ""
                }`}
                onChange={formik.handleChange}
                // disabled={isDetails}
              ></TextField>
              {formik.touched.description && formik.errors.description && (
                <span className='text-red-500'>
                  {formik.errors.description}
                </span>
              )}

              {formik.values.plans.map((exercise, i) => {
                return (
                  <Grid container key={i}>
                    <Grid
                      item
                      lg={12}
                      justifyContent='center'
                      display='flex'
                      direction='column'
                    >
                      <Stack direction='row' spacing={2}>
                        <Stack direction='column' className='w-full '>
                          <InputLabel>Select workout</InputLabel>
                          <Select name='[exercise.id]' />
                          {formik.touched.exercises &&
                            formik.errors.exercises && (
                              <span className='text-red-500'>
                                {formik.errors.exercises}
                              </span>
                            )}
                        </Stack>
                      </Stack>
                    </Grid>
                  </Grid>
                );
              })}
              <Stack
                direction='row'
                spacing={2}
                className='items-center justify-end'
              >
                <Typography>
                  Please specify how many workouts you want to add to this plan
                  -{" "}
                  <span className='text-red-400'>
                    workouts are distributed by weeks
                  </span>{" "}
                  so with, for eg. 7 workouts included an user will have them
                  assigned on each day of the week
                </Typography>
                <Select
                  defaultValue={1}
                  onChange={(e) => {
                    onChangeWorkouts(e);
                  }}
                >
                  {noOfExercieses.map((number) => {
                    return (
                      <MenuItem key={number} value={number}>
                        {number}
                      </MenuItem>
                    );
                  })}
                </Select>
              </Stack>
              <Grid container>
                <Grid
                  item
                  lg={12}
                  justifyContent='center'
                  display='flex'
                  direction='column'
                >
                  <Stack direction='row' spacing={2}>
                    <Stack direction='column' className='w-full'>
                      <InputLabel>Weeks</InputLabel>
                      <Select name='[exercise.id]' />
                      {formik.touched.exercises && formik.errors.exercises && (
                        <span className='text-red-500'>
                          {formik.errors.exercises}
                        </span>
                      )}
                    </Stack>
                    <Stack direction='column' className='w-full '>
                      <InputLabel>Price</InputLabel>
                      <TextField name='[exercise.sets]' />
                      {formik.touched.bodyPart && formik.errors.bodyPart && (
                        <span className='text-red-500'>
                          {formik.errors.bodyPart}
                        </span>
                      )}
                    </Stack>
                  </Stack>
                  <Stack direction='row' spacing={2} className='mt-6'>
                    <Stack direction='column' className='w-full'>
                      <InputLabel>Language</InputLabel>
                      <Select name='[exercise.id]' />
                      {formik.touched.exercises && formik.errors.exercises && (
                        <span className='text-red-500'>
                          {formik.errors.exercises}
                        </span>
                      )}
                    </Stack>
                    <Stack direction='column' className='w-full '>
                      <InputLabel>Skill level</InputLabel>
                      <Select name='[exercise.sets]' />
                      {formik.touched.bodyPart && formik.errors.bodyPart && (
                        <span className='text-red-500'>
                          {formik.errors.bodyPart}
                        </span>
                      )}
                    </Stack>
                  </Stack>
                </Grid>
              </Grid>
              <InputLabel>Status</InputLabel>
              <Select
                name='status'
                defaultValue={statuses[0]}
                value={formik.values.status}
                error={formik.touched.status && Boolean(formik.errors.status)}
                className={`${
                  formik.touched.status && formik.errors.status
                    ? "border-red-500"
                    : ""
                }`}
                onChange={formik.handleChange}
                // disabled={isDetails}
              >
                {statuses.map((status) => {
                  return (
                    <MenuItem key={status} value={status}>
                      {status}
                    </MenuItem>
                  );
                })}
              </Select>
              {formik.touched.status && formik.errors.status && (
                <span className='text-red-500'>{formik.errors.status}</span>
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
                  formik.setFieldValue("plans", [basePlan]);
                  handleClose();
                }}
                className={"w-1/2"}
              >
                {/* {isDetails ? "Close" : "Cancel"} */}
                Cancel
              </Button>
              {/* {!isDetails && ( */}
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
            </div>
          </div>
        </form>
      </Dialog>
    </>
  );
}

export default TrainingPlanModal;
