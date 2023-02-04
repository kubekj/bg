import style from "./training-preview.module.css"
import React from "react";

const TrainingPreview = ({workout}) => {

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
                </div>
            </div>
        </div>
    );
}

export default TrainingPreview;