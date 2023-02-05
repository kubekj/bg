import React from "react";
import Link from "next/link";

import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { Button, Dialog, Grid, InputLabel, TextField } from "@mui/material";
import CustomButton from "../../../reusable/button";
import { Stack } from "@mui/system";

function TrainingPlanPreview(props) {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const {
    workout,
    icon,
    backgroundColorValue,
    isHoveringColor,
    text,
    extraStyleType,
    extraStyleValue,
  } = props;
  console.log(workout)
  return (
    <>
      <CustomButton
        iconSrc={icon}
        text={text}
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
                Workout
              </Typography>

                <Typography
                  id='modal-modal-title'
                  variant='h6'
                  component='h2'
                  onClick={handleClose}
                  className="cursor-pointer"
                >
                    X
                </Typography>

            </div>
            <Typography
              id='modal-modal-description'
              className='text-gray-600'
              sx={{ mt: 1 }}
            >
              Training details provided below
            </Typography>
          </div>
          <div className='flex flex-col items-start p-10 gap-5 w-full'>
            <div className='flex flex-col justify-center gap-3 w-full'>
              <Typography id='modal-modal-title' variant='h3' component='h2'>
                Healthy back
              </Typography>
              <hr />
              <Grid container>
                <Grid
                  item
                  lg={12}
                  justifyContent='center'
                  display='flex'
                  direction='column'
                >{workout.exerciseDtos.map(exercise => {
                  return(
                      <Stack direction='row' spacing={2} id={exercise.id}>
                        <Stack direction='column' className='w-full'>
                          <InputLabel>Exercise</InputLabel>
                          <TextField placeholder={exercise.name} disabled={true}></TextField>
                        </Stack>
                        <Stack direction='column'>
                          <InputLabel>Sets</InputLabel>
                          <TextField placeholder={exercise.setDtos.length} disabled={true}></TextField>
                        </Stack>
                        <Stack direction='column'>
                          <InputLabel>Reps</InputLabel>
                          <TextField placeholder={exercise.setDtos[0].repetitions} disabled={true}></TextField>
                        </Stack>
                      </Stack>
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

          <div className='flex flex-col px-8 w-full items-center'>
            <div className='flex flex-row w-full gap-3 py-6'>
              <Button
                style={{
                  backgroundColor: "#8098F9",
                  borderRadius: 10,
                }}
                variant='contained'
                onClick={handleClose}
                className='w-full'
              >
                Close
              </Button>
            </div>
          </div>
        </div>
      </Dialog>
    </>
  );
}

export default TrainingPlanPreview;
