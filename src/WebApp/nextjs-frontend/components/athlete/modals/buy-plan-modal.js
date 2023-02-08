import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import Link from "next/link";
import { useRouter } from "next/router";
import { useSession } from "next-auth/react";
import { poster } from "../../../lib/rest-api";

import Typography from "@mui/material/Typography";
import { Button, Dialog, InputLabel, TextField } from "@mui/material";
import CustomButton from "../../reusable/button";
import { Stack } from "@mui/system";

const validationSchema = yup.object().shape({
  cardNumber: yup.string().required("Please provide card number"),
  fullName: yup.string().required("Please provide your name and surname "),
  validTo: yup.string().required("Please provide valid month and year"),
  ccv: yup.string().required("Please provide ccv code").length(3),
});

function BuyPlanModal(props) {
  const router = useRouter();
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const { data } = useSession();
  const {
    trainingPlan,
    icon,
    backgroundColorValue,
    isHoveringColor,
    extraStyleType,
    extraStyleValue,
  } = props;

  const formik = useFormik({
    initialValues: {
      trainingId: trainingPlan.id,
      cardNumber: "",
      fullName: "",
      validTo: "",
      ccv: "",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      await poster(`training-plans/buy/${trainingPlan.id}`, values, data.jwt);
      router.replace("/athlete/training");
      handleClose();
    },
  });

  return (
    <>
      <CustomButton
        iconSrc={icon}
        text={"Buy plan"}
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
                Buy training plan
              </Typography>
              <Typography
                id='modal-modal-title'
                variant='h6'
                component='h2'
                onClick={handleClose}
                className='cursor-pointer'
              >
                x
              </Typography>
            </div>
            <Typography
              id='modal-modal-description'
              className='text-gray-600'
              sx={{ mt: 1 }}
            >
              {trainingPlan.title}
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
                <Stack gap={2} className='w-full'>
                  <Typography
                    className='w-full text-gray-700'
                    variant='h6'
                    component='h4'
                  >
                    This plan will cost you
                    <span className='text-indigo-400 pl-2'>
                      ${trainingPlan.price}
                    </span>{" "}
                    $
                  </Typography>
                </Stack>
              </Stack>
              <TextField
                name='cardNumber'
                label='Card number'
                value={formik.values.cardNumber}
                error={
                  formik.touched.cardNumber && Boolean(formik.errors.cardNumber)
                }
                className={`${
                  formik.touched.cardNumber && formik.errors.cardNumber
                    ? "border-red-500"
                    : ""
                }`}
                onChange={formik.handleChange}
              ></TextField>
              {formik.touched.cardNumber && formik.errors.cardNumber && (
                <span className='text-red-500'>{formik.errors.cardNumber}</span>
              )}
              <TextField
                name='fullName'
                label='Full name'
                value={formik.values.fullName}
                error={
                  formik.touched.fullName && Boolean(formik.errors.fullName)
                }
                className={`${
                  formik.touched.fullName && formik.errors.fullName
                    ? "border-red-500"
                    : ""
                }`}
                onChange={formik.handleChange}
              ></TextField>
              {formik.touched.fullName && formik.errors.fullName && (
                <span className='text-red-500'>{formik.errors.fullName}</span>
              )}
              <Stack
                container
                direction={"row"}
                className='items-center'
                gap={4}
              >
                <TextField
                  name='validTo'
                  label='Valid to'
                  placeholder='MM/YYYY'
                  value={formik.values.validTo}
                  error={
                    formik.touched.validTo && Boolean(formik.errors.validTo)
                  }
                  className={`${
                    formik.touched.validTo && formik.errors.validTo
                      ? "border-red-500"
                      : ""
                  }`}
                  onChange={formik.handleChange}
                ></TextField>
                {formik.touched.validTo && formik.errors.validTo && (
                  <span className='text-red-500'>{formik.errors.validTo}</span>
                )}
                <TextField
                  name='ccv'
                  type='password'
                  label='CCV'
                  value={formik.values.ccv}
                  error={formik.touched.ccv && Boolean(formik.errors.ccv)}
                  className={`${
                    formik.touched.ccv && formik.errors.ccv
                      ? "border-red-500"
                      : ""
                  }`}
                  onChange={formik.handleChange}
                ></TextField>
                {formik.touched.ccv && formik.errors.ccv && (
                  <span className='text-red-500'>{formik.errors.ccv}</span>
                )}
              </Stack>
            </div>
          </div>

          <div className='flex flex-col px-6 py-2 w-full items-center'>
            <div className='flex flex-row w-full gap-3 py-6'>
              <Button
                style={{
                  backgroundColor: "#D0D5DD",
                  color: "#000000",
                  borderRadius: 10,
                  border: "none",
                }}
                variant='outlined'
                onClick={handleClose}
                className={"w-1/2"}
              >
                Cancel
              </Button>
              <Button
                style={{
                  backgroundColor: "#8098F9",
                  borderRadius: 10,
                }}
                variant='contained'
                type='submit'
                className='w-1/2'
              >
                Buy
              </Button>
            </div>
          </div>
        </form>
      </Dialog>
    </>
  );
}

export default BuyPlanModal;
