import style from "./training-preview.module.css"
import React from "react";

const TrainingPreview = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <b>Healthy back</b>
                    <p>Upper-body</p>
                    <p>8 exercises</p>
                </div>
                <div className={style.infoRight}>
                    <p>Full body</p>
                </div>
            </div>
        </div>
    );
}

export default TrainingPreview;