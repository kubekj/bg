import style from "./workouts-list.module.css";
import Link from "next/link";
import Button from "../../../reusable-comps/button";
import React from "react";

import DeleteModal from "../../../reusable-comps/delete-modal";
import WorkoutModal from "../../athlete-modals/workout-modal";

const WorkoutsList = ({ workouts }) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h2>Workouts</h2>
        <p>Manage workouts here.</p>
      </div>
      <div className={style.tableContainer}>
        <div className={style.header}>
          <div className={style.info}>
            <div>
              <h4>
                <b>Workout</b>
              </h4>
            </div>
            <div style={{ marginBottom: "0.75rem" }}>
              <WorkoutModal
                icon='/thumbnails/add-outline.svg'
                text='Add new'
                backgroundColorValue='#8098F9'
                isHoveringColor='#C7D7FE'
                extraStyleType='color'
                extraStyleValue='white'
                isDetails={false}
              />
            </div>
          </div>
        </div>
        <div>
          <table className={style.tableOfTrainings}>
            <thead className={style.tHead}>
              <tr>
                <th className={style.thRegular}>Name</th>
                <th className={style.thRegular}>Category</th>
                <th className={style.thRegular}>No. of exercises</th>
                <th className={style.thRegular}>Actions</th>
              </tr>
            </thead>
            <tbody className={style.tBody}>
              {workouts.map((workout) => {
                return (
                  <tr key={workout.id}>
                    <td className={style.tdRegular}>{workout.name}</td>
                    <td className={style.tdRegular}>
                      <div
                        className={style.infoProgress}
                        style={{ backgroundColor: "#F9F5FF", color: "#98B3DB" }}
                      >
                        {workout.category}
                      </div>
                    </td>
                    <td className={style.tdRegular}>
                      {workout.exerciseDtos.length}
                    </td>
                    <td className={style.tdRegular} style={{ padding: "0" }}>
                      <Button
                        iconSrc='/thumbnails/copy-outline.svg'
                        backgroundColorValue='white'
                        isHoveringColor='#D0D5DD'
                        borderValue='none'
                      />
                      <Button
                        iconSrc='/thumbnails/modify.svg'
                        backgroundColorValue='white'
                        isHoveringColor='#D0D5DD'
                        borderValue='none'
                      />
                      <DeleteModal
                        subtitle={`Remove workout "${workout.name}"`}
                        endpoint={`workouts/${workout.id}`}
                        redirect='/athlete/workout'
                      />
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

export default WorkoutsList;
