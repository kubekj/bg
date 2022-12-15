import style from "./previous-training.module.css";
import React from "react";
import Button from "./../../button";
import Image from 'next/image'
import {valueOrDefault} from "chart.js/helpers";

const PreviousTraining = () => {

    const sampleData = [{
            trainingName: "FBW - Push",
            load:{
               value: "1233 kg",
               percentage: "10",
               progress: true
            },
            satisfaction:{
                value: "7/10",
                percentage: "12",
                progress: true
            },
            fatigue: {
                value: "5/10",
                percentage: "10",
                progress: false
        }
    }];

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
            fatigueProgress: false
    }

    return(
        <div className={style.container}>
            <div className={style.topSection}>
                <div className={style.info}>
                    <p>Previous training</p>
                    <h3>{sampleData.map(a => a.trainingName)}</h3>
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
                            <h3>{sampleData.map(a => a.load.value)}</h3>
                            <div className={style.infoProgress}
                                 style={{backgroundColor: sampleData.map(a => a.load.progress) ? "#ECFDF3" : "#FEF3F2",
                                     color: sampleData.map(a => a.load.progress) ? "#027A48" : "#B42318"
                                 }}
                            >
                                <Image src={sampleData.map(a => a.load.percentage) ? "/thumbnails/arrow-up-green.svg" : "/thumbnails/arrow-down-red.svg"} width={18} height={18}/>
                                <p>{sampleData.map(a => a.load.percentage)}%</p>
                            </div>
                        </div>
                    </div>
                    <div className={style.info}>
                        <p>Satisfaction</p>
                        <div className={style.data}>
                            <h3>{sampleData.map(a => a.satisfaction.value)}</h3>
                            <div className={style.infoProgress}
                                 style={{backgroundColor: sampleData.map(a => a.satisfaction.progress) ? "#ECFDF3" : "#FEF3F2",
                                     color: sampleData.map(a => a.satisfaction.progress) ? "#027A48" : "#B42318"
                                 }}
                            >
                                <Image src={simpleSampleData.satisfactionProgress ? "/thumbnails/arrow-up-green.svg" : "/thumbnails/arrow-down-red.svg"} width={18} height={18}/>
                                <p>{sampleData.map(a => a.satisfaction.percentage)}%</p>
                            </div>
                        </div>
                    </div>
                    <div className={style.info}>
                        <p>Fatigue</p>
                        <div className={style.data}>
                            <h3>{sampleData.map(a => a.fatigue.value)}</h3>
                            <div className={style.infoProgress}
                                 style={{
                                     backgroundColor: sampleData.map(a => a.fatigue.progress) ? "#ECFDF3" : "#FEF3F2",
                                     color: sampleData.map(a => a.fatigue.progress) ? "#027A48" : "#B42318"
                            }}
                            >
                                <Image src={simpleSampleData.fatigueProgress ? "/thumbnails/arrow-up-green.svg" : "/thumbnails/arrow-down-red.svg"} width={18} height={18}/>
                            <p>{sampleData.map(a => a.fatigue.percentage)}%</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div className={style.buttonRight}>
                    <Button iconSrc="/thumbnails/checkout.svg"
                            text="Check out workout"
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

export default PreviousTraining;