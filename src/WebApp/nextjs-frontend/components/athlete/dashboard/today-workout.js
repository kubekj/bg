import style from "./today-training.module.css";
import Button from "../../reusable/button";
import React from "react";
import Link from "next/link";

const TodayWorkout = ({ current }) => {
  // console.log("Current");
  // console.log(current.code);
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
          <Link href='/athlete/calendar'>
            <Button
              iconSrc='/thumbnails/wcalendar-number-outline.svg'
              text='Calendar'
              borderValue='none'
              backgroundColorValue='#8098F9'
              isHoveringColor='#C7D7FE'
              extraStyleType='color'
              extraStyleValue='white'
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
                <th className={style.thRegular}>Sets</th>
                <th className={style.thRegular}>Body part</th>
                <th className={style.thRegular}>Reps</th>
                <th className={style.thRegular}>Weight</th>
              </tr>
            </thead>
            <tbody className={style.tBody}>
              {
                current?.exerciseDtos?.map((exercise) => {
                return (
                  <tr key={exercise.id}>
                    <td className={style.tdRegular}>{exercise.name}</td>
                    <td className={style.tdRegular}>
                      {exercise.setDtos.length}
                    </td>
                    <td className={style.tdRegular}>
                      <div
                        className={style.infoProgress}
                        style={{ backgroundColor: "#F9F5FF", color: "#98B3DB" }}
                      >
                        {exercise.bodyPart}
                      </div>
                    </td>
                    <td className={style.tdRegular}>
                      {exercise.setDtos[0].repetitions}
                    </td>
                    <td className={style.tdRegular}>
                      {exercise.setDtos[0].weight}
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
};

export default TodayWorkout;
