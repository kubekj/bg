import style from "./today-training.module.css";
import Button from "../button";
import React from "react";

const TodayTraining = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h4>Today training</h4>
                        <p>Keep track of your weight stats</p>
                    </div>
                </div>
                <div className={style.buttonCalendar}>
                        <Button iconSrc="/thumbnails/wcalendar-number-outline.svg"
                                text="Calendar"
                                borderValue="none"
                                backgroundColorValue="#8098F9"
                                isHoveringColor="#C7D7FE"
                                extraStyleType="color"
                                extraStyleValue="white"
                        />
                </div>
            </div>
            <div className={style.bottomSection}>
                    <h1>FULL BODY WORKOUT</h1>
                <div className={style.buttonDetails}>
                    <Button iconSrc="/thumbnails/arrow-redo-outline.svg"
                            text="View details"
                            backgroundColorValue="white"
                            isHoveringColor="#D0D5DD"
                            extraStyleType="border"
                            extraStyleValue="1px solid #D0D5DD"
                    />

                </div>
            </div>
        </div>
    );
}

export default TodayTraining;