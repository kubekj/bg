import style from "./today-training.module.css";
import Button from "../../reusable/button";
import React from "react";
import Link from "next/link";


const TodayWorkout = ({workouts}) => {
    console.log(workouts);
    return (
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h4>Today training</h4>
                        <p>Keep track of your weight stats</p>
                    </div>
                </div>
                <div className={style.buttonCalendar}>
                    <Link href="/athlete/calendar">
                        <Button iconSrc="/thumbnails/wcalendar-number-outline.svg"
                                text="Calendar"
                                borderValue="none"
                                backgroundColorValue="#8098F9"
                                isHoveringColor="#C7D7FE"
                                extraStyleType="color"
                                extraStyleValue="white"
                        />
                    </Link>
                </div>
            </div>
            <div className={style.bottomSection}>
                <div className={style.tableContainer}>
                    <table className={style.tableOfTrainings}>
                        <thead className={style.tHead}>
                        <tr>
                            <th className={style.thRegular}>Name</th>
                            <th className={style.thRegular}>Category</th>
                            <th className={style.thRegular}>No. of exercises</th>
                        </tr>
                        </thead>
                        <tbody className={style.tBody}>
                        {workouts?.map((workout) => {
                            return (
                                <tr key={workout.id}>
                                    <td className={style.tdRegular}>{workout.name}</td>
                                    <td className={style.tdRegular}>
                                        <div
                                            className={style.infoProgress}
                                            style={{backgroundColor: "#F9F5FF", color: "#98B3DB"}}
                                        >
                                            {workout.category}
                                        </div>
                                    </td>
                                    <td className={style.tdRegular}>
                                        {workout.exerciseDtos.length}
                                    </td>
                                </tr>
                            );
                        })}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default TodayWorkout;