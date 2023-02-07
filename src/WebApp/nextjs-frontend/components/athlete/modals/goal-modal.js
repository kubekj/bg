import React from "react";
import { useFormik } from "formik";
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

const validationSchema = yup.object().shape({
  goal: yup
    .number()
    .required("Please set monthly goal of how many workouts should you do")
    .max(25),
});

function GoalModal({ goal }) {
  const router = useRouter();
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const { data } = useSession();

  const formik = useFormik({
    initialValues: {
      name: goal ? goal.value : 1,
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      exercise
        ? await putter(`exercises/${exercise.id}`, values, data.jwt)
        : await poster("exercises/create", values, data.jwt);
      router.replace("/athlete/exercise");
      handleClose();
    },
  });

  return <div>GoalModal</div>;
}

export default GoalModal;
