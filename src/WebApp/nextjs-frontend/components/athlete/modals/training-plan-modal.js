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

const statuses = ["Unpublished", "Published"];
const languages = ["English", "Polish"];
const skillLevels = ["Beginner", "Intermediate", "Advanced"];
const noOfExercieses = [1, 2, 3, 4, 5, 6, 7];
const baseWorkout = {};

function convertForEdit(workouts) {
  return workouts.map((workout) => {
    workout.id;
  });
}

const validationSchema = yup.object().shape({
  title: yup.string().required("Please provide a title for plan"),
  description: yup.string().required("Please describe the plan"),
  workouts: yup.array().of(yup.string().required("training is required")),
  duration: yup
    .number()
    .required("Please mark how long will the training last (in weeks)"),
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
  noOfWorkouts: yup
    .number()
    .required("Mark how many workouts will the plan contain"),
});

function TrainingPlanModal(props) {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const { data } = useSession();
  const router = useRouter();
  const { plan, workouts, isDetails } = props;

  const formik = useFormik({
    initialValues: {
      title: plan ? plan.title : "",
      description: plan ? plan.description : "",
      workouts: plan ? plan.workouts.map(({ id }) => id) : [baseWorkout],
      duration: plan ? plan.duration : "",
      price: plan ? plan.price : "",
      language: plan ? plan.language : "",
      skillLevel: plan ? plan.skillLevel : "",
      status: plan ? plan.status : "",
      noOfWorkouts: plan ? plan.noOfWorkouts : 1,
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      if (plan) {
        await putter(`training-plans/${plan.id}`, values, data.jwt);
        router.replace("/trainer/plans");
      } else {
        await poster("training-plans/create", values, data.jwt);
        formik.handleReset();
      }
      router.replace("/trainer/plans");
      handleClose();
    },
  });

  function onChangeWorkouts(e) {
    // update dynamic form
    const workouts = formik.values.workouts;
    //console.log(workouts);
    const numberOfWorkouts = e.target.value || 0;
    const previousNumber = parseInt(formik.values.noOfWorkouts || "0");
    if (previousNumber < numberOfWorkouts) {
      for (let i = previousNumber; i < numberOfWorkouts; i++) {
        workouts.push({});
      }
    } else {
      for (let i = previousNumber; i >= numberOfWorkouts; i--) {
        workouts.splice(i, 1);
      }
    }
    formik.setFieldValue("workouts", workouts);
    // call formik onChange method
    formik.setFieldValue("noOfWorkouts", e.target.value);
  }

  const title = !props.plan ? "Create new plan" : "Plan details";
  const btnlabel = !props.plan ? "Add" : "Edit";

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
              <InputLabel>Title</InputLabel>
              <TextField
                name='title'
                value={formik.values.title}
                placeholder='eg. Push'
                error={formik.touched.title && Boolean(formik.errors.title)}
                className={`${
                  formik.touched.title && formik.errors.title
                    ? "border-red-500"
                    : ""
                }`}
                onChange={formik.handleChange}
                disabled={isDetails}
              ></TextField>
              {formik.touched.title && formik.errors.title && (
                <span className='text-red-500'>{formik.errors.title}</span>
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
                disabled={isDetails}
              ></TextField>
              {formik.touched.description && formik.errors.description && (
                <span className='text-red-500'>
                  {formik.errors.description}
                </span>
              )}

              {formik.values.workouts.map((workout, i) => {
                return (
                  <Grid container key={i}>
                    <Grid
                      container
                      item
                      lg={12}
                      justifyContent='center'
                      display='flex'
                      direction='column'
                    >
                      <Stack direction='row' spacing={2}>
                        <Stack direction='column' className='w-full '>
                          <InputLabel>Workout</InputLabel>
                          <Select
                            name={`workouts.${i}`}
                            value={workout}
                            error={
                              formik.touched.workouts &&
                              Boolean(formik.errors.workouts)
                            }
                            className={`${
                              formik.touched.workouts && formik.errors.workouts
                                ? "border-red-500"
                                : ""
                            }`}
                            onChange={formik.handleChange}
                            disabled={isDetails}
                          >
                            {workouts.map((workout) => {
                              return (
                                <MenuItem key={workout.id} value={workout.id}>
                                  {workout.name}
                                </MenuItem>
                              );
                            })}
                          </Select>
                          {formik.touched.workouts &&
                            formik.touched.workouts[i] &&
                            formik.touched.workouts[i] &&
                            formik.errors.workouts && (
                              <span className='text-red-500'>
                                {formik.errors.workouts[i]}
                              </span>
                            )}
                        </Stack>
                      </Stack>
                    </Grid>
                  </Grid>
                );
              })}
              {!isDetails && (
                <Stack
                  direction='row'
                  spacing={2}
                  className='items-center justify-end'
                >
                  <Typography>
                    Please specify how many workouts you want to add to this
                    plan -{" "}
                    <span className='text-red-400'>
                      workouts are distributed by weeks
                    </span>{" "}
                    so with, for eg. 7 workouts included an user will have them
                    assigned on each day of the week
                  </Typography>
                  <Select
                    value={formik.values.noOfWorkouts}
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
              )}
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
                      <TextField
                        type='number'
                        name='duration'
                        value={formik.values.duration}
                        error={
                          formik.touched.duration &&
                          Boolean(formik.errors.duration)
                        }
                        className={`${
                          formik.touched.duration && formik.errors.duration
                            ? "border-red-500"
                            : ""
                        }`}
                        onChange={formik.handleChange}
                        disabled={isDetails}
                      />
                      {formik.touched.duration && formik.errors.duration && (
                        <span className='text-red-500'>
                          {formik.errors.duration}
                        </span>
                      )}
                    </Stack>
                    <Stack direction='column' className='w-full '>
                      <InputLabel>Price</InputLabel>
                      <TextField
                        name='price'
                        value={formik.values.price}
                        error={
                          formik.touched.price && Boolean(formik.errors.price)
                        }
                        className={`${
                          formik.touched.price && formik.errors.price
                            ? "border-red-500"
                            : ""
                        }`}
                        onChange={formik.handleChange}
                        disabled={isDetails}
                      />
                      {formik.touched.price && formik.errors.price && (
                        <span className='text-red-500'>
                          {formik.errors.price}
                        </span>
                      )}
                    </Stack>
                  </Stack>
                  <Stack direction='row' spacing={2} className='mt-6'>
                    <Stack direction='column' className='w-full'>
                      <InputLabel>Language</InputLabel>
                      <Select
                        name='language'
                        value={formik.values.language}
                        error={
                          formik.touched.language &&
                          Boolean(formik.errors.language)
                        }
                        className={`${
                          formik.touched.language && formik.errors.language
                            ? "border-red-500"
                            : ""
                        }`}
                        onChange={formik.handleChange}
                        disabled={isDetails}
                      >
                        {languages.map((language) => {
                          return (
                            <MenuItem key={language} value={language}>
                              {language}
                            </MenuItem>
                          );
                        })}
                      </Select>
                      {formik.touched.language && formik.errors.language && (
                        <span className='text-red-500'>
                          {formik.errors.language}
                        </span>
                      )}
                    </Stack>
                    <Stack direction='column' className='w-full '>
                      <InputLabel>Skill level</InputLabel>
                      <Select
                        name='skillLevel'
                        value={formik.values.skillLevel}
                        error={
                          formik.touched.skillLevel &&
                          Boolean(formik.errors.skillLevel)
                        }
                        className={`${
                          formik.touched.skillLevel && formik.errors.skillLevel
                            ? "border-red-500"
                            : ""
                        }`}
                        onChange={formik.handleChange}
                        disabled={isDetails}
                      >
                        {skillLevels.map((skillLevel) => {
                          return (
                            <MenuItem key={skillLevel} value={skillLevel}>
                              {skillLevel}
                            </MenuItem>
                          );
                        })}
                      </Select>
                      {formik.touched.skillLevel &&
                        formik.errors.skillLevel && (
                          <span className='text-red-500'>
                            {formik.errors.skillLevel}
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
                disabled={isDetails}
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
                  if (!plan && !isDetails)
                    formik.setFieldValue("workouts", [baseWorkout]);
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
      </Dialog>
    </>
  );
}

export default TrainingPlanModal;
