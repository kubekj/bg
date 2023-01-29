import style from "./header.module.css";
import { useFormik } from "formik";
import * as Yup from "yup";

import { getSession, signIn } from "next-auth/react";
import ButtonsSection from "./buttons-section";
import Image from "next/image";
import logo from "../../public/logo.png";
import fetcher, { poster, signin } from "../../lib/rest-api";
import Router from "next/router";

const validationSchema = Yup.object({
  email: Yup.string(),
  password: Yup.string(),
});

const LogInContent = () => {
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      const response = await signIn("credentials", {
        email: values.email,
        password: values.password,
        redirect: false,
      });

      // var response = await signin(values);
      // if (response.code && response.reason)
      //   return alert("incorrect credentials");
      // setToken(response);
      // var jwt = getTokenFromLocalCookie();
      // var options = {
      //   headers: {
      //     Authorization: `Bearer ${jwt}`,
      //   },
      // };
      // response = await fetcher("workouts", options);
      //   Router.push("/");
      console.log(response);
      alert(JSON.stringify(response, null, 2));
    },
  });

  return (
    <div>
      <form onSubmit={formik.handleSubmit}>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput' className='form-label'>
            Email
          </label>
          <input
            type='email'
            name='email'
            id='email'
            placeholder='f.e. john.doe@gmail.com'
            value={formik.values.email}
            onChange={formik.handleChange}
            error={formik.touched.userId && Boolean(formik.errors.userId)}
            className={`form-control ${
              formik.touched.email && formik.errors.email
                ? "border-red-500"
                : ""
            }`}
          />
          {formik.touched.email && formik.errors.email && (
            <span className='text-red-500'>{formik.errors.userId}</span>
          )}
        </div>
        <div className='mb-3'>
          <label htmlFor='formGroupExampleInput2' className='form-label'>
            Password
          </label>
          <input
            type='password'
            className='form-control'
            name='password'
            id='password'
            placeholder='******'
            value={formik.values.password}
            onChange={formik.handleChange}
          />
        </div>
        <div className={style.bottomSection}>
          <div className='form-check w-50'>
            <input
              className='form-check-input'
              type='checkbox'
              value=''
              id='flexCheckDefault'
            />
            <label className='form-check-label' htmlFor='flexCheckDefault'>
              Remember for 30 days
            </label>
          </div>
          <div>
            <a
              className={`text-decoration-none`}
              style={{ color: "#98B3DB" }}
              href='#'
            >
              Forgot password
            </a>
          </div>
        </div>
        <ButtonsSection
          topButtonText='Sign in'
          bottomButtonText='Sign in with Google'
          leftBottomSectionText='Dont have an account?'
          rightBottomSectionText='Sign up!'
          className='submit'
        />
        <button type='submit'></button>
      </form>
    </div>
  );
};

export default LogInContent;
