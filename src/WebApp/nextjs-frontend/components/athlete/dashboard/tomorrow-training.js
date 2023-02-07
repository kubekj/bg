import style from "./tomorrow-training.module.css";
import React from "react";
import TrainingPlanPreview from "../training/training-plans/training-preview-dialog";

const TomorrowTraining = ({workout, title}) => {
    const dateToDisplay = workout.item2 ? new Date(Date.parse(workout.item2)) : null;

    return (
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h4>{title ? title : "Test"}</h4>
                        <p>{dateToDisplay ? dateToDisplay.toDateString().split(" ")[1] : ""} {dateToDisplay ? dateToDisplay.toDateString().split(" ")[2] : ""}</p>
                    </div>
                </div>
            </div>
            <div className={style.bottomSection}>
                <h2>{workout.item1 ? workout.item1.name : "No data"}</h2>
            </div>
            <div className={style.hrCustom}/>
            <div className={style.bottomSection2}>
                {workout.item1 ?
                    <TrainingPlanPreview
                        icon='/thumbnails/wthunder.svg'
                        text='Check out training'
                        extraStyleType='color'
                        extraStyleValue='white'
                        backgroundColorValue='#8098F9'
                        isHoveringColor='#C7D7FE'
                        borderValue='none'
                        workout={workout.item1}

                    /> : ""
                }
            </div>
        </div>
    );
};

export default TomorrowTraining;
