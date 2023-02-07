import style from "./recent-preview.module.css"
import React from "react";

const RecentPreview = ({plan}) => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <b>{plan ? plan.title : ""}</b>
                    <p>{plan ? plan.category: ""}</p>
                    <p>{plan ? plan.noOfWorkouts : ""} workouts</p>
                </div>
                <div className={plan.skillLevel === "Beginner" ? style.infoRightB : (plan.skillLevel === "Advanced" ? style.infoRightA : style.infoRightI)}>
                    <p>{plan ? plan.skillLevel : ""}</p>
                </div>
            </div>
        </div>
    );
}

export default RecentPreview;