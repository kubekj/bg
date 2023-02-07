import { useFormik } from "formik";
import * as Yup from "yup";

import fetcher, { poster } from "../../lib/rest-api";
import Router from "next/router";
import { Button, TextField } from "@mui/material";
import { Stack } from "@mui/system";

const validationSchema = Yup.object({
  firstName: Yup.string().required("please provide your name"),
  lastName: Yup.string().required("please provide your surname"),
  email: Yup.string().email().required("please provide an email"),
  password: Yup.string().required("password cannot be empty").min(6),
});

const SignInContent = () => {
  const formik = useFormik({
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      const correctSignin = await poster("users/signup", values);

      Router.push("/auth/login");
    },
  });

  return (
    <>
      <form onSubmit={formik.handleSubmit}>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput' className='form-label'>
            First Name
          </label>
          <Stack>
            <TextField
              name='firstName'
              placeholder='John'
              value={formik.values.firstName}
              onChange={formik.handleChange}
              error={
                formik.touched.firstName && Boolean(formik.errors.firstName)
              }
              className={`${
                formik.touched.firstName && formik.errors.firstName
                  ? "border-red-500"
                  : ""
              }`}
            />
            {formik.touched.firstName && formik.errors.firstName && (
              <span className='text-red-500'>{formik.errors.firstName}</span>
            )}
          </Stack>
        </div>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput2' className='form-label'>
            Last Name
          </label>
          <Stack>
            <TextField
              placeholder='Doe'
              error={formik.touched.lastName && Boolean(formik.errors.lastName)}
              className={`${
                formik.touched.lastName && formik.errors.lastName
                  ? "border-red-500"
                  : ""
              }`}
              name='lastName'
              value={formik.values.lastName}
              onChange={formik.handleChange}
            />
            {formik.touched.lastName && formik.errors.lastName && (
              <span className='text-red-500'>{formik.errors.lastName}</span>
            )}
          </Stack>
        </div>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput2' className='form-label'>
            Email
          </label>
          <Stack>
            <TextField
              placeholder='john.doe@gmail.com'
              error={formik.touched.email && Boolean(formik.errors.email)}
              className={`${
                formik.touched.password && formik.errors.password
                  ? "border-red-500"
                  : ""
              }`}
              name='email'
              value={formik.values.email}
              onChange={formik.handleChange}
            />
            {formik.touched.email && formik.errors.email && (
              <span className='text-red-500'>{formik.errors.email}</span>
            )}
          </Stack>
        </div>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput2' className='form-label'>
            Password
          </label>
          <Stack>
            <TextField
              type='password'
              error={formik.touched.password && Boolean(formik.errors.password)}
              className={`${
                formik.touched.password && formik.errors.password
                  ? "border-red-500"
                  : "border-red-500"
              }`}
              name='password'
              placeholder='******'
              value={formik.values.password}
              onChange={formik.handleChange}
            />
            {formik.touched.password && formik.errors.password && (
              <span className='text-red-500'>{formik.errors.password}</span>
            )}
          </Stack>
        </div>
        <Button
          type='submit'
          variant='contained'
          className='w-full mt-4'
          style={{ backgroundColor: "#98B3DB" }}
        >
          Register
        </Button>
      </form>
    </>
  );
};

export default SignInContent;
