import style from "../reusable-comps/training-view.module.css"
import React from "react";
import Image from "next/image";
import TrainingPreview from "./training-preview";
import Link from "next/link";
import {Rating, Typography} from "@mui/material";
import Button from "./button";

const TrainingView = ({header, backHref, detailsHref, trainingName, applyButtonText, planDescription}) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h3>{header}</h3>
                <div className={style.mainImage}/>
            </div>
            <div className={style.content}>
                <div className={style.midHeader}>
                    <Link href={backHref}>
                        <Button iconSrc="/thumbnails/arrow-back-outline.svg"
                                text="Return to plans"
                                borderValue="none"
                                backgroundColorValue="white"
                                isHoveringColor="#C7D7FE"
                                extraStyleType="color"
                                extraStyleValue="#8098F9"
                        />
                    </Link>
                    <h2>{trainingName}</h2>
                </div>
                <div className={style.details}>
                    <h5>Length: 4 weeks</h5>
                    <h5>Number of exercises: 6</h5>
                    <div className={style.description}>
                        <div>
                            <h5>Plan description</h5>
                            <p>{planDescription}</p>
                        </div>
                        <div>
                            <div className={style.bottomSection}>
                                <div className={style.userInfo}>
                                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30}
                                           height={30}/>
                                    <div>
                                        <h5>Creator</h5>
                                        <p>adsasda@dsaasd.pl</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h5 style={{color: "#8098F9"}}>Workouts</h5>
                </div>
                <div className={style.bottom}>
                    <div className={style.trainings}>
                        <div>
                            <Link href={detailsHref} style={{textDecoration:"none"}}>
                                <TrainingPreview/>
                            </Link>
                        </div>
                        <div>
                            <TrainingPreview/>
                        </div>
                        <div>
                            <TrainingPreview/>
                        </div>
                        <div>
                            <TrainingPreview/>
                        </div>
                        <div>
                            <TrainingPreview/>
                        </div>
                    </div>
                    <div className={style.rightBottom}>
                        <div className={style.rating}>
                            <p>Rating</p>
                            <Typography component="legend"/>
                            <Rating
                                name="simple-controlled"
                                value={5}
                                // onChange={(event, newValue) => {
                                //     setValue(newValue);
                                // }}
                            /><p>202 reviews</p>
                            <b>4.02</b>
                            <h5>Rate plan</h5>
                        </div>
                        <div className={style.apply}>
                            <Button iconSrc="/thumbnails/checkmark-outline.svg"
                                    text={applyButtonText}
                                    borderValue="none"
                                    backgroundColorValue="#8098F9"
                                    isHoveringColor="#C7D7FE"
                                    extraStyleType="color"
                                    extraStyleValue="white"
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TrainingView;