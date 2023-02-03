import style from "./training-plan.module.css";
import React from "react";
import Button from "../../../reusable/button";
import Link from "next/link";

const TrainingPlan = ({ plans }) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <div className={style.info}>
          <div>
            <h5>
              <b>Latest training plans</b>
            </h5>
          </div>
          <div style={{ marginBottom: "0.75rem" }}>
            <Link href='/athlete/training/trainings'>
              <Button
                iconSrc='/thumbnails/copy-outline.svg'
                text='See all'
                backgroundColorValue='white'
                isHoveringColor='#D0D5DD'
                extraStyleType='border'
                extraStyleValue='1px solid #D0D5DD'
              />
            </Link>
          </div>
        </div>
      </div>
      <div className={style.midSection}>
        <table className={style.tableOfTrainings}>
          <thead className={style.tHead}>
            <tr>
              <th className={style.thRegular}>Training name</th>
              <th className={style.thRegular}>Duration</th>
              <th className={style.thRegular}>Purchase date</th>
              <th className={style.thRegular}>Skill level</th>
              <th className={style.thRegular}>Author</th>
            </tr>
          </thead>
          <tbody className={style.tBody}>
            {plans.map((plan) => {
              return (
                <tr key={plan.title}>
                  <td className={style.tdRegular}>{plan.title}</td>
                  <td className={style.tdRegular}>{plan.duration}</td>
                  <td className={style.tdRegular}>{plan.creatorEmail}</td>
                  <td className={style.tdRegular}>{plan.skillLevel}</td>
                  <td className={style.tdRegular}>{plan.creatorEmail}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TrainingPlan;
