import React, { useState, useEffect } from "react";
import { useFormik, setFieldValue } from "formik";
import * as yup from "yup";
import Link from "next/link";
import { useRouter } from "next/router";
import { useSession } from "next-auth/react";
import { poster, putter } from "../../../lib/rest-api";

import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { Button, InputLabel, MenuItem, TextField } from "@mui/material";
import CustomButton from "../../reusable/button";
import { Select } from "@mui/material";
import { Stack } from "@mui/system";

const categories = ["Upper", "Lower", "Full", "Cardio"];
const noOfExercieses = [1, 2, 3, 4, 5, 6, 7];

const validationSchema = yup.object().shape({
  name: yup.string().required("Please provide a name for workout"),
  category: yup.string().required("Please choose the category of this workout"),
  exercises: yup.array().of(
    yup.object().shape({
      id: yup.string().required("Exercise is required"),
      sets: yup.array().of(
        yup.object().shape({
          repetitions: yup.number().required("Please provide number of reps"),
          weight: yup
            .number()
            .required("Please provide weight (0 if it's bodyweight)"),
        })
      ),
    })
  ),
});

function WorkoutModal(props) {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const { data } = useSession();
  const router = useRouter();
  const { workout } = props;

  const initialValues = {
    name: workout ? workout.name : "",
    bodyPart: workout ? workout.category : "",
    exercises: workout ? workout.exercises : [],
    noOfExercieses: 1,
  };

  const formik = useFormik({
    initialValues: {
      name: workout ? workout.name : "",
      bodyPart: workout ? workout.category : "",
      exercises: workout ? workout.exercises : [],
      noOfExercieses: 1,
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {},
  });

  function onChangeExercises(e, field, values) {
    // update dynamic form
    const exercises = formik.values.exercises;
    const numberOfExercises = formik.values.noOfExercieses;
    const previousNumber = parseInt(field.value || "0");
    if (previousNumber < numberOfExercises) {
      for (let i = previousNumber; i < numberOfExercises; i++) {
        exercises.push({ id: "", sets: { repetitions: "", weight: "" } });
      }
    } else {
      for (let i = previousNumber; i >= numberOfExercises; i--) {
        exercises.splice(i, 1);
      }
    }

    formik.values.exercises = exercises;

    // call formik onChange method
  }

  const title = !props.workout ? "Create new workout" : "Workout details";
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
                // disabled={isDetails}
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

              {/* Handling of exercise addition */}
              {formik.values.exercises.map((exercise, i) => {
                return (
                  <Grid conatiner key={i}>
                    <Grid
                      item
                      lg={12}
                      justifyContent='center'
                      display='flex'
                      direction='column'
                      key={i}
                    >
                      <Stack direction='row' spacing={2}>
                        <Stack direction='column' className='w-full '>
                          <InputLabel>Select exercise</InputLabel>
                          <Select name='bodyPart' />
                          {formik.touched.bodyPart &&
                            formik.errors.bodyPart && (
                              <span className='text-red-500'>
                                {formik.errors.bodyPart}
                              </span>
                            )}
                        </Stack>
                        <Stack direction='column'>
                          <InputLabel>Sets</InputLabel>
                          <TextField name='bodyPart' />
                          {formik.touched.bodyPart &&
                            formik.errors.bodyPart && (
                              <span className='text-red-500'>
                                {formik.errors.bodyPart}
                              </span>
                            )}
                        </Stack>
                        <Stack direction='column'>
                          <InputLabel>Reps</InputLabel>
                          <TextField name='bodyPart' />
                          {formik.touched.bodyPart &&
                            formik.errors.bodyPart && (
                              <span className='text-red-500'>
                                {formik.errors.bodyPart}
                              </span>
                            )}
                        </Stack>
                        <Stack direction='column'>
                          <InputLabel>Weight</InputLabel>
                          <TextField name='bodyPart' />
                          {formik.touched.bodyPart &&
                            formik.errors.bodyPart && (
                              <span className='text-red-500'>
                                {formik.errors.bodyPart}
                              </span>
                            )}
                          {formik.touched.bodyPart &&
                            formik.errors.bodyPart && (
                              <span className='text-red-500'>
                                {formik.errors.bodyPart}
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
                <InputLabel>
                  Please specify how much exercises you want to add to this
                  workout
                </InputLabel>
                <Select
                  name='noOfExercieses'
                  value={formik.values.noOfExercieses}
                  onChange={(e) => {
                    onChangeExercises(
                      e,
                      formik.values.noOfExercieses,
                      formik.values.exercises
                    );
                    formik.handleChange(e);
                    console.log(formik.values.noOfExercieses);
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
      </Modal>
    </>
  );
}

const generateTable = (formik, rows) => {
  return rows.map((row) => {
    return (
      <Grid conatiner key={row.id}>
        <Grid
          item
          lg={12}
          justifyContent='center'
          display='flex'
          direction='column'
          key={row.id}
        >
          <Stack direction='row' spacing={2}>
            <Stack direction='column' className='w-full '>
              <InputLabel>Select exercise</InputLabel>
              <Select name='bodyPart' />
              {formik.touched.bodyPart && formik.errors.bodyPart && (
                <span className='text-red-500'>{formik.errors.bodyPart}</span>
              )}
            </Stack>
            <Stack direction='column'>
              <InputLabel>Sets</InputLabel>
              <TextField name='bodyPart' />
              {formik.touched.bodyPart && formik.errors.bodyPart && (
                <span className='text-red-500'>{formik.errors.bodyPart}</span>
              )}
            </Stack>
            <Stack direction='column'>
              <InputLabel>Reps</InputLabel>
              <TextField name='bodyPart' />
              {formik.touched.bodyPart && formik.errors.bodyPart && (
                <span className='text-red-500'>{formik.errors.bodyPart}</span>
              )}
            </Stack>
            <Stack direction='column'>
              <InputLabel>Weight</InputLabel>
              <TextField name='bodyPart' />
              {formik.touched.bodyPart && formik.errors.bodyPart && (
                <span className='text-red-500'>{formik.errors.bodyPart}</span>
              )}
              {formik.touched.bodyPart && formik.errors.bodyPart && (
                <span className='text-red-500'>{formik.errors.bodyPart}</span>
              )}
            </Stack>
          </Stack>
        </Grid>
      </Grid>
    );
  });
};

export default WorkoutModal;
