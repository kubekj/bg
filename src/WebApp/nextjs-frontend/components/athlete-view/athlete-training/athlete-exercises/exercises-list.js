import style from "./exercise-list.module.css";
import React from "react";
import ExerciseModal from "../../athlete-modals/exercise-modal";
import DeleteModal from "../../../reusable-comps/delete-modal";

const ExercisesList = ({ exercises }) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h2>Exercises</h2>
        <p>Manage your exercises here.</p>
      </div>
      <div className={style.tableContainer}>
        <div className={style.header}>
          <div className={style.info}>
            <div>
              <h4>
                <b>Exercise</b>
              </h4>
            </div>
            <div style={{ marginBottom: "0.75rem" }}>
              <ExerciseModal
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
                <th className={style.thRegular}>Body Part</th>
                <th className={style.thRegular}>Category</th>
                <th className={style.thRegular}></th>
              </tr>
            </thead>
            <tbody className={style.tBody}>
              {exercises.map((exercise) => {
                return (
                  <tr key={exercise.id}>
                    <td className={style.tdRegular}>{exercise.name}</td>
                    <td className={style.tdRegular}>
                      <div
                        className={style.infoProgress}
                        style={{ backgroundColor: "#F9F5FF", color: "#98B3DB" }}
                      >
                        {exercise.bodyPart}
                      </div>
                    </td>
                    <td className={style.tdRegular}>{exercise.category}</td>
                    <td className={style.tdRegular} style={{ padding: "0" }}>
                      <ExerciseModal
                        icon='/thumbnails/copy-outline.svg'
                        isDetails={true}
                        exercise={exercise}
                        backgroundColorValue='white'
                        isHoveringColor='#D0D5DD'
                        borderValue='none'
                      />
                      <ExerciseModal
                        icon='/thumbnails/modify.svg'
                        isDetails={false}
                        exercise={exercise}
                        backgroundColorValue='white'
                        isHoveringColor='#D0D5DD'
                        borderValue='none'
                      />
                      <DeleteModal
                        subtitle={`Remove exercise "${exercise.name}"`}
                        endpoint={`exercises/${exercise.id}`}
                        redirect='/athlete/exercise'
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

export default ExercisesList;
