import style from "../settings/settings.module.css";
import { useFormik } from "formik";
import * as yup from "yup";
import { Button, MenuItem, Select, TextField } from "@mui/material";
import { putter } from "../../lib/rest-api";
import { signIn, useSession } from "next-auth/react";
import Router from "next/router";

const languages = ["English", "Polish"];

const validationSchema = yup.object().shape({
  firstName: yup.string().required("Please provide your name"),
  lastName: yup.string().required("Please provide your last name"),
  email: yup.string().required("Please provide an email"),
  bio: yup.string().required("Please describe yourself"),
  preferredLanguage: yup.string().required("Please choose preferred language"),
  weight: yup.number().required("Please provide your current weight"),
  weightGoal: yup.number().required("Please provide your weight goal"),
  height: yup.number().required("Please provide your height"),
  caloriesIntake: yup
    .number()
    .required("Please provide your daily calories intake"),
  caloriesIntakeGoal: yup
    .number()
    .required("Please provide your daily calories intake goal"),
});

const SettingsView = ({ user }) => {
  const { data } = useSession();

  const formik = useFormik({
    initialValues: {
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      bio: user.description,
      preferredLanguage: user.preferredLanguage,
      weight: user.weight ? user.weight : "",
      weightGoal: user.weight ? user.weightGoal : "",
      height: user.height ? user.height : "",
      caloriesIntake: user.caloriesIntake ? user.caloriesIntake : "",
      caloriesIntakeGoal: user.caloriesIntake ? user.caloriesIntakeGoal : "",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      await putter(`users/details`, values, data.jwt);
      data.user.email = values.email;
      data.user.fullName = `${values.firstName} ${values.lastName}`;
      Router.replace("/athlete/settings");
    },
  });

  console.log(user);

  return (
    <div className={style.container}>
      <div>
        <h1>Settings</h1>
      </div>
      <div className={style.header}>
        <h5>Personal info</h5>
        <p>Update your personal data here</p>
      </div>
      <form className={style.main} onSubmit={formik.handleSubmit}>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{ paddingTop: "2rem" }}
        >
          <span className='input-group-text w-48'>First and last name</span>
          <div className='flex flex-row w-full gap-6'>
            <TextField
              label='Name'
              name='firstName'
              value={formik.values.firstName}
              error={
                formik.touched.firstName && Boolean(formik.errors.firstName)
              }
              className={
                "w-full" +
                `${
                  formik.touched.firstName && formik.errors.firstName
                    ? "border-red-500"
                    : ""
                }`
              }
              onChange={formik.handleChange}
            />
            {formik.touched.firstName && formik.errors.firstName && (
              <span className='text-red-500'>{formik.errors.firstName}</span>
            )}
            <TextField
              label='Surname'
              name='lastName'
              value={formik.values.lastName}
              error={formik.touched.lastName && Boolean(formik.errors.lastName)}
              className={
                "w-full" +
                `${
                  formik.touched.lastName && formik.errors.lastName
                    ? "border-red-500"
                    : ""
                }`
              }
              onChange={formik.handleChange}
            />
            {formik.touched.lastName && formik.errors.lastName && (
              <span className='text-red-500'>{formik.errors.lastName}</span>
            )}
          </div>
        </div>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{
            paddingTop: "1rem",
          }}
        >
          <span className='input-group-text w-48'>Email</span>
          <TextField
            label='Email'
            name='email'
            value={formik.values.email}
            error={formik.touched.email && Boolean(formik.errors.email)}
            className={
              "w-full" +
              `${
                formik.touched.email && formik.errors.email
                  ? "border-red-500"
                  : ""
              }`
            }
            onChange={formik.handleChange}
          />
          {formik.touched.email && formik.errors.email && (
            <span className='text-red-500'>{formik.errors.email}</span>
          )}
        </div>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{
            paddingTop: "1rem",
          }}
        >
          <span className='input-group-text w-48 h-16'>Description</span>
          <TextField
            label='Bio'
            multiline
            rows={4}
            name='bio'
            value={formik.values.bio}
            error={formik.touched.bio && Boolean(formik.errors.bio)}
            className={`w-full ${
              formik.touched.bio && formik.errors.bio ? "border-red-500" : ""
            }`}
            onChange={formik.handleChange}
          />
          {formik.touched.bio && formik.errors.bio && (
            <span className='text-red-500'>{formik.errors.bio}</span>
          )}
        </div>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{
            paddingTop: "1rem",
            paddingBottom: "1rem",
            borderBottom: "1px solid #D0D5DD",
          }}
        >
          <span className='input-group-text w-48' id='addon-wrapping'>
            Preferred language
          </span>
          <Select
            name='preferredLanguage'
            value={formik.values.preferredLanguage}
            error={
              formik.touched.preferredLanguage &&
              Boolean(formik.errors.preferredLanguage)
            }
            className={`w-full ${
              formik.touched.preferredLanguage &&
              formik.errors.preferredLanguage
                ? "border-red-500"
                : ""
            }`}
            onChange={formik.handleChange}
          >
            {languages.map((language) => {
              return (
                <MenuItem key={language} value={language}>
                  {language}
                </MenuItem>
              );
            })}
          </Select>
        </div>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{ paddingTop: "1rem" }}
        >
          <span className='input-group-text w-48' id='addon-wrapping'>
            Height (cm)
          </span>
          <TextField
            label='Height'
            name='height'
            value={formik.values.height}
            error={formik.touched.height && Boolean(formik.errors.height)}
            className={
              "w-full" +
              `${
                formik.touched.height && formik.errors.height
                  ? "border-red-500"
                  : ""
              }`
            }
            onChange={formik.handleChange}
          />
          {formik.touched.height && formik.errors.height && (
            <span className='text-red-500'>{formik.errors.height}</span>
          )}
        </div>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{ paddingTop: "1rem" }}
        >
          <span className='input-group-text w-48' id='addon-wrapping'>
            Calories (kcal)
          </span>
          <div className='flex flex-row w-full gap-6'>
            <TextField
              label='Calories intake'
              name='caloriesIntake'
              value={formik.values.caloriesIntake}
              error={
                formik.touched.caloriesIntake &&
                Boolean(formik.errors.caloriesIntake)
              }
              className={
                "w-full" +
                `${
                  formik.touched.caloriesIntake && formik.errors.caloriesIntake
                    ? "border-red-500"
                    : ""
                }`
              }
              onChange={formik.handleChange}
            />
            {formik.touched.caloriesIntake && formik.errors.caloriesIntake && (
              <span className='text-red-500'>
                {formik.errors.caloriesIntake}
              </span>
            )}
            <TextField
              label='Calories intake goal'
              name='caloriesIntakeGoal'
              value={formik.values.caloriesIntakeGoal}
              error={
                formik.touched.caloriesIntakeGoal &&
                Boolean(formik.errors.caloriesIntakeGoal)
              }
              className={`w-full ${
                formik.touched.caloriesIntakeGoal &&
                formik.errors.caloriesIntakeGoal
                  ? "border-red-500"
                  : ""
              }`}
              onChange={formik.handleChange}
            />
            {formik.touched.caloriesIntakeGoal &&
              formik.errors.caloriesIntakeGoal && (
                <span className='text-red-500'>
                  {formik.errors.caloriesIntakeGoal}
                </span>
              )}
          </div>
        </div>
        <div
          className='mx-auto flex flex-row gap-6'
          style={{ paddingTop: "1rem" }}
        >
          <span className='input-group-text w-48' id='addon-wrapping'>
            Weight (kg)
          </span>
          <div className='flex flex-row w-full gap-6'>
            <TextField
              label='Weight'
              name='weight'
              value={formik.values.weight}
              error={formik.touched.weight && Boolean(formik.errors.weight)}
              className={
                "w-full" +
                `${
                  formik.touched.weight && formik.errors.weight
                    ? "border-red-500"
                    : ""
                }`
              }
              onChange={formik.handleChange}
            />
            {formik.touched.weight && formik.errors.weight && (
              <span className='text-red-500'>{formik.errors.weight}</span>
            )}
            <TextField
              label='Weight goal'
              name='weightGoal'
              value={formik.values.weightGoal}
              error={
                formik.touched.weightGoal && Boolean(formik.errors.weightGoal)
              }
              className={
                "w-full" +
                `${
                  formik.touched.weightGoal && formik.errors.weightGoal
                    ? "border-red-500"
                    : ""
                }`
              }
              onChange={formik.handleChange}
            />
            {formik.touched.weightGoal && formik.errors.weightGoal && (
              <span className='text-red-500'>{formik.errors.weightGoal}</span>
            )}
          </div>
        </div>
        <div
          className='d-grid gap-2 d-md-flex justify-content-md-end'
          style={{ paddingTop: "2rem" }}
        >
          <Button
            style={{
              backgroundColor: "#D0D5DD",
              color: "#000000",
              borderRadius: 10,
              border: "none",
            }}
            variant='outlined'
            onClick={formik.handleReset}
          >
            Reset
          </Button>
          <Button
            style={{
              backgroundColor: "#8098F9",
              borderRadius: 10,
            }}
            variant='contained'
            type='submit'
          >
            Save
          </Button>
        </div>
      </form>
    </div>
  );
};

export default SettingsView;
