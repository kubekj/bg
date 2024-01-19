import style from "./previous-training.module.css";
import React from "react";
import Button from "../../../reusable/button";
import Image from "next/image";

const PreviousTraining = () => {
    const sampleData = {
        trainingName: "FBW - Push",
        load: {
            value: "1233 kg",
            percentage: "10",
            progress: true,
        },
        satisfaction: {
            value: "7/10",
            percentage: "12",
            progress: true,
        },
        fatigue: {
            value: "5/10",
            percentage: "10",
            progress: false,
        },
    };

    const simpleSampleData = {
        trainingName: "FBW - Push",
        loadValue: "1233kg",
        loadPercentage: "10",
        loadProgress: true,
        satisfactionValue: "7/10",
        satisfactionPercentage: "12",
        satisfactionProgress: true,
        fatigueValue: "5/10",
        fatiguePercentage: "10",
        fatigueProgress: false,
    };

    return (
        <div className={style.container}>
            <div className={style.topSection}>
                <div className={style.info}>
                    <p>Previous training</p>
                    <h3>{sampleData.trainingName}</h3>
                </div>
                <div className={style.infoRight}>
                    <p>Full body</p>
                </div>
            </div>
            <div className={style.bottomSection}>
                <div className={style.statisticsLeft}>
                    <div className={style.info}>
                        <p>Load</p>
                        <div className={style.data}>
                            <h3>{sampleData.load.value}</h3>
                            <div
                                className={style.infoProgress}
                                style={{
                                    backgroundColor: sampleData.load.progress
                                        ? "#ECFDF3"
                                        : "#FEF3F2",
                                    color: sampleData.load.progress ? "#027A48" : "#B42318",
                                }}
                            >
                                <Image
                                    src={
                                        simpleSampleData.loadProgress
                                            ? "/thumbnails/arrow-up-green.svg"
                                            : "/thumbnails/arrow-down-red.svg"
                                    }
                                    width={18}
                                    height={18}
                                />
                                <p>{sampleData.load.percentage}%</p>
                            </div>
                        </div>
                        {sampleData.load.progress}
                    </div>
                    <div className={style.info}>
                        <p>Satisfaction</p>
                        <div className={style.data}>
                            <h3>{sampleData.satisfaction.value}</h3>
                            <div
                                className={style.infoProgress}
                                style={{
                                    backgroundColor: sampleData.satisfaction.progress
                                        ? "#ECFDF3"
                                        : "#FEF3F2",
                                    color: sampleData.satisfaction.progress
                                        ? "#027A48"
                                        : "#B42318",
                                }}
                            >
                                <Image
                                    src={
                                        simpleSampleData.satisfactionProgress
                                            ? "/thumbnails/arrow-up-green.svg"
                                            : "/thumbnails/arrow-down-red.svg"
                                    }
                                    width={18}
                                    height={18}
                                />
                                <p>{sampleData.satisfaction.percentage}%</p>
                            </div>
                        </div>
                    </div>
                    <div className={style.info}>
                        <p>Fatigue</p>
                        <div className={style.data}>
                            <h3>{sampleData.fatigue.value}</h3>
                            <div
                                className={style.infoProgress}
                                style={{
                                    backgroundColor: sampleData.fatigue.progress
                                        ? "#ECFDF3"
                                        : "#FEF3F2",
                                    color: sampleData.fatigue.progress ? "#027A48" : "#B42318",
                                }}
                            >
                                <Image
                                    src={
                                        simpleSampleData.fatigueProgress
                                            ? "/thumbnails/arrow-up-green.svg"
                                            : "/thumbnails/arrow-down-red.svg"
                                    }
                                    width={18}
                                    height={18}
                                />
                                <p>{sampleData.fatigue.percentage}%</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div className={style.buttonRight}>
                    <Button
                        iconSrc='/thumbnails/checkout.svg'
                        text='Check out workout'
                        backgroundColorValue='white'
                        isHoveringColor='#D0D5DD'
                        extraStyleType='border'
                        extraStyleValue='1px solid #D0D5DD'
                    />
                </div>
            </div>
        </div>
    );
};

export default PreviousTraining;
