import style from "./tomorrow-training.module.css";
import React from "react";
import TrainingPlanPreview from "../training/training-plans/training-preview-dialog";

const TomorrowTraining = ({workout, title, date}) => {
    const today = new Date();
    let dateToDisplay = new Date();
    dateToDisplay.setDate(today.getDate() + date);
    return (
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h4>{title}</h4>
                        <p>{dateToDisplay.toDateString().split(" ")[1]} {dateToDisplay.toDateString().split(" ")[2]}</p>
                    </div>
                </div>
            </div>
            <div className={style.bottomSection}>
                <h2>{workout.name}</h2>
            </div>
            <div className={style.hrCustom}/>
            <div className={style.bottomSection2}>
                <TrainingPlanPreview
                    icon='/thumbnails/wthunder.svg'
                    text='Check out training'
                    extraStyleType='color'
                    extraStyleValue='white'
                    backgroundColorValue='#8098F9'
                    isHoveringColor='#C7D7FE'
                    borderValue='none'
                    workout={workout}
                />
            </div>
        </div>
    );
};

export default TomorrowTraining;
