import { useFormik } from "formik";
import * as Yup from "yup";

import { toast } from "react-toastify";
import { signIn } from "next-auth/react";
import ButtonsSection from "./buttons-section";
import { signin } from "../../lib/rest-api";
import Router from "next/router";
import { Button, TextField } from "@mui/material";
import { Stack } from "@mui/system";

const validationSchema = Yup.object({
  email: Yup.string().email().required("please provide an email"),
  password: Yup.string().required("password cannot be empty"),
});

const LogInContent = () => {
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      const correctLogin = await signin(values);

      if (correctLogin.code && correctLogin.reason)
        return toast.error("Invalid credentials");

      if (correctLogin)
        await signIn("credentials", {
          email: values.email,
          password: values.password,
          redirect: false,
        }).then(({ ok }) => {
          if (ok) {
            Router.push("/athlete/dashboard");
          }
        });
    },
  });

  return (
    <>
      <form onSubmit={formik.handleSubmit}>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput' className='form-label'>
            Email
          </label>
          <Stack>
            <TextField
              name='email'
              placeholder='f.e. john.doe@gmail.com'
              value={formik.values.email}
              onChange={formik.handleChange}
              error={formik.touched.email && Boolean(formik.errors.email)}
              className={`${
                formik.touched.email && formik.errors.email
                  ? "border-red-500"
                  : ""
              }`}
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
              className={`${
                formik.touched.password && formik.errors.password
                  ? "border-red-500"
                  : ""
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
          Log in
        </Button>
        <ButtonsSection
          leftBottomSectionText='Dont have an account?'
          rightBottomSectionText='Sign up!'
          isLogin={true}
        />
      </form>
    </>
  );
};

export default LogInContent;
