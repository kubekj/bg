import style from "./tomorrow-training.module.css";
import Button from "../reusable-comps/button";
import React from "react";

const TomorrowTraining = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h4>Tomorrow</h4>
                        <p>4 January</p>
                    </div>
                </div>

            </div>
            <div className={style.bottomSection}>
                <h2>FULL BODY WORKOUT</h2>
            </div>
            <div className={style.hrCustom}>

            </div>
            <div className={style.bottomSection2}>
                <Button iconSrc="/thumbnails/wthunder.svg" text="Check out training" extraStyleType="color" extraStyleValue="white"
                        borderValue="none"
                        backgroundColorValue="#8098F9"
                        isHoveringColor="#C7D7FE"
                />
            </div>
        </div>
    );
}

export default TomorrowTraining;