import React, { useState } from "react";
import { Calendar, momentLocalizer } from "react-big-calendar";
import moment from "moment";
import "react-big-calendar/lib/css/react-big-calendar.css";
import TrainingPlanPreview from "../training/training-plans/training-preview-dialog";
import { Box } from "@mui/system";
import { Button, Modal, Typography } from "@mui/material";

const CalendarView = ({ workouts }) => {
  const [selectedEvent, setSelectedEvent] = useState(undefined);
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const handleSelectedEvent = (event) => {
    let workout = null;
    console.log(open);
    workout = workouts.map((w) => {
      if (w.workoutDto.id === event.id) {
        workout = w.workoutDto;
        setSelectedEvent(workout);
        handleOpen();
        console.log(selectedEvent);
      }
    });
  };

  const localizer = momentLocalizer(moment);

  let data = [];

  workouts.map((workout) => {
    data.push({
      id: workout.workoutDto.id,
      start: workout.date,
      end: workout.date,
      title: workout.workoutDto.name,
    });
  });

  return (
    <div className='App' style={{ marginLeft: "1rem", flex: "1" }}>
      <Calendar
        views={["month"]}
        localizer={localizer}
        events={data}
        popup={true}
        startAccessor='start'
        endAccessor='end'
        style={{ height: "95vh", flex: "1" }}
        onDoubleClickEvent={(e) => handleSelectedEvent(e)}
        onSelectEvent={() => handleClose()}
      />
      <div>
        {selectedEvent && open && (
          <TrainingPlanPreview
            workout={selectedEvent}
            isOpen={open}
          ></TrainingPlanPreview>
        )}
        ;
      </div>
    </div>
  );
};

export default CalendarView;

//   const onDoubleClick = (event) => {
//     console.log(event)
//     let workout = null;

//     workout = workouts.map((w) => {
//       if (w.workoutDto.id === event.id) {
//         workout = w.workoutDto;
//         console.log(workout);
//         setSelectedEvent(workout);
//         return (
//           <TrainingPlanPreview workout={workout} isOpen={true} key={w.id} />
//         );
//         setExtraSection(<TrainingPlanPreview workout={workout}/>);
//         return <TrainingPlanPreview workout={workout}/>;
//       }
//     });
//     return setExtraSection(workout => {<TrainingPlanPreview workout={workout}/>});
//     return <TrainingPlanPreview workout={workout}/>;
//     return <></>;
//   };

//   setExtraSection(() => onDoubleClick());
