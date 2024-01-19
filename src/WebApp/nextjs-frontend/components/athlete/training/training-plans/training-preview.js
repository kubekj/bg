import style from "./training-preview.module.css"
import React from "react";

const TrainingPreview = ({workout, children}) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <b>{workout ? workout.name : ""}</b>
                    <p>{workout ? workout.category : ""}</p>
                    <p>{workout ? workout.exerciseDtos.length : ""} exercises</p>
                </div>
                <div className={style.infoRight}>
                    <p>{workout ? workout.category : ""}</p>
                    {children}
                </div>
            </div>
        </div>
    );
}

export default TrainingPreview;