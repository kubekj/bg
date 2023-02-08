import React, { useState } from "react";

import Typography from "@mui/material/Typography";
import { Button, Dialog, Grid, InputLabel, TextField } from "@mui/material";
import CustomButton from "../../reusable/button";
import { Stack } from "@mui/system";

function AssignPlanModal(props) {
  const {
    plan,
    icon,
    backgroundColorValue,
    isHoveringColor,
    extraStyleType,
    extraStyleValue,
  } = props;
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <>
      <CustomButton
        iconSrc={icon}
        text={"Apply plan"}
        backgroundColorValue={backgroundColorValue}
        borderValue='none'
        isHoveringColor={isHoveringColor}
        extraStyleType={extraStyleType}
        extraStyleValue={extraStyleValue}
        onClick={handleOpen}
      />
      <Dialog open={open} onClose={handleClose}>
        <div className='relative top-1/4 mx-auto flex flex-col items-center bg-white w-full rounded-xl'>
          <div className='flex flex-col isolate w-full bg-gray-200 p-10 rounded-t-xl'>
            <div className='flex flex-row place-content-between w-full'>
              <Typography id='modal-modal-title' variant='h6' component='h2'>
                Apply training plan
              </Typography>

              <Typography
                id='modal-modal-title'
                variant='h6'
                component='h2'
                onClick={handleClose}
                className='cursor-pointer'
              >
                X
              </Typography>
            </div>
            <Typography
              id='modal-modal-description'
              className='text-gray-600'
              sx={{ mt: 1 }}
            >
              Training plan details provided below
            </Typography>
          </div>
          <div className='flex flex-col items-start p-10 gap-5 w-full'>
            <div className='flex flex-col justify-center gap-3 w-full'>
              <Typography id='modal-modal-title' variant='h3' component='h2'>
                {plan.title}
              </Typography>
              <Typography
                id='modal-modal-description'
                className='text-gray-700'
                sx={{ mt: 1 }}
              >
                {plan.description}
              </Typography>
              <hr />
              <Typography
                id='modal-modal-description'
                className='flex text-gray-700 justify-center text-xl'
                sx={{ mt: 1 }}
              >
                The plan lasts {plan.duration} weeks
              </Typography>
              <Grid container>
                <Grid
                  item
                  lg={12}
                  justifyContent='center'
                  display='flex'
                  direction='column'
                >
                  {plan.workouts.map((workout) => {
                    return (
                      <div key={workout.id} className='p-2'>
                        <Stack direction='row' spacing={2}>
                          <Stack direction='column' className='w-full'>
                            <InputLabel>Workout name</InputLabel>
                            <TextField
                              placeholder={workout.name}
                              disabled={true}
                              sx={{
                                ".MuiInputBase-input.Mui-disabled": {
                                  WebkitTextFillColor: "#000",
                                  color: "#000",
                                },
                              }}
                            ></TextField>
                          </Stack>
                          <Stack direction='column' className='w-1/3'>
                            <InputLabel>No. of exercises</InputLabel>
                            <TextField
                              placeholder={workout.exerciseDtos.length}
                              disabled={true}
                              sx={{
                                ".MuiInputBase-input.Mui-disabled": {
                                  WebkitTextFillColor: "#000",
                                  color: "#000",
                                },
                              }}
                            ></TextField>
                          </Stack>
                        </Stack>
                      </div>
                    );
                  })}
                </Grid>
              </Grid>
              <Stack direction='row' spacing={2} className='items-center'>
                <Stack
                  direction='column'
                  spacing={2}
                  className='items-center'
                ></Stack>
              </Stack>
            </div>
          </div>

          <div className='flex flex-col px-6 py-2 w-full items-center'>
            <div className='flex flex-row w-full gap-3 py-6'>
              {/* Date picker */}
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
                Apply
              </Button>
            </div>
          </div>
        </div>
      </Dialog>
    </>
  );
}

export default AssignPlanModal;
