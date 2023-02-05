import style from "./training-preview.module.css"
import React from "react";
import TrainingPlanPreview from "./training-preview-dialog";

const TrainingPreview = ({workout, children}) => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <b>{workout.name}</b>
                    <p>{workout.category}</p>
                    <p>{workout.exerciseDtos.length} exercises</p>
                </div>
                <div className={style.infoRight}>
                    <p>{workout.category}</p>
                    {children}
                </div>
            </div>
        </div>
    );
}

export default TrainingPreview;