import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import Link from "next/link";
import { useRouter } from "next/router";
import { useSession } from "next-auth/react";
import { poster } from "../../../lib/rest-api";

import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { Button, Dialog, InputLabel, MenuItem, TextField } from "@mui/material";
import CustomButton from "../../reusable/button";
import { Select } from "@mui/material";
import { Stack } from "@mui/system";

const validationSchema = yup.object().shape({
  goal: yup.number().required("Please set monthly goal").max(25).min(1),
});

function GoalModal(props) {
  const router = useRouter();
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const { data } = useSession();
  const {
    goal,
    isDetails,
    icon,
    backgroundColorValue,
    isHoveringColor,
    extraStyleType,
    extraStyleValue,
  } = props;

  const formik = useFormik({
    initialValues: {
      goal: goal ? goal : 1,
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      await poster("statistics/goal", values, data.jwt);
      router.replace("/athlete/dashboard");
      handleClose();
    },
  });
  const title = goal ? "Change current goal" : "Set new goal";

  return (
    <>
      <CustomButton
        iconSrc={icon}
        text={"Set goal"}
        backgroundColorValue={backgroundColorValue}
        borderValue='none'
        isHoveringColor={isHoveringColor}
        extraStyleType={extraStyleType}
        extraStyleValue={extraStyleValue}
        onClick={handleOpen}
      />
      <Dialog open={open} onClose={handleClose}>
        <form
          onSubmit={formik.handleSubmit}
          className='relative top-1/4 mx-auto flex flex-col items-center bg-white w-full rounded-xl'
        >
          <div className='flex flex-col isolate w-full bg-gray-200 p-10'>
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
              <Stack
                gap={2}
                container
                direction={"row"}
                className='items-center'
              >
                <Stack gap={2} className='w-2/3'>
                  <Typography
                    className='w-full text-gray-700'
                    variant='h6'
                    component='h4'
                  >
                    Please provide how many workouts you would like to do this
                    <span className='text-indigo-400'> month</span> and you'll
                    see the results on given chart
                  </Typography>
                </Stack>
                <Stack className='w-1/3'>
                  <TextField
                    name='goal'
                    label='No. of workouts'
                    value={formik.values.goal}
                    error={formik.touched.goal && Boolean(formik.errors.goal)}
                    className={`${
                      formik.touched.goal && formik.errors.goal
                        ? "border-red-500"
                        : ""
                    }`}
                    onChange={formik.handleChange}
                  ></TextField>
                  {formik.touched.goal && formik.errors.goal && (
                    <span className='text-red-500'>{formik.errors.goal}</span>
                  )}
                </Stack>
              </Stack>
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
                  if (goal) formik.handleReset();
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
                  Set
                </Button>
              )}
            </div>
          </div>
        </form>
      </Dialog>
    </>
  );
}

export default GoalModal;
