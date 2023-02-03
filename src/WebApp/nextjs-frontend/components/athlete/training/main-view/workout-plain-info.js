import style from "./workout-plain-info.module.css";
import Button from "../../../reusable/button";
import React from "react";
import Link from "next/link";

const WorkoutPlainInfo = () => {
  return (
    <div className={style.container}>
      <div className={style.info}>
        <h3>
          Check already available
          <span style={{ color: "#8098F9" }}> workouts</span> and start right
          away or if feasible create one on your own!
        </h3>
      </div>
      <div className={style.buttons}>
        <Link href='/athlete-exercises'>
          <Button
            iconSrc='/thumbnails/copy-outline.svg'
            text='Workouts'
            backgroundColorValue='white'
            isHoveringColor='#D0D5DD'
            extraStyleType='border'
            extraStyleValue='1px solid #D0D5DD'
          />
        </Link>
        <Button
          iconSrc='/thumbnails/add-own.svg'
          text='Add own'
          backgroundColorValue='#EEF4FF'
          isHoveringColor='#8098F9'
          borderValue='none'
          extraStyleType='color'
          extraStyleValue='#6172F3'
        />
      </div>
    </div>
  );
};

export default WorkoutPlainInfo;
