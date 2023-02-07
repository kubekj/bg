import style from "./apply-training-view.module.css";
import Button from "../../../reusable/button";
import React from "react";
import Image from "next/image";
import TrainingPreview from "./training-preview";
import Link from "next/link";
import {Rating, Typography} from "@mui/material";
import TrainingPlanPreview from "./training-preview-dialog";
import {poster} from "../../../../lib/rest-api";
import {useRouter} from "next/router";

const ApplyTrainingView = ({plan, jwt}) => {
    const router  = useRouter();

    const ratePlan = async (value) => {
        await poster(`training-plans/rate/${plan.id}`,{rate: value}, jwt);

        await router.replace(`/athlete/training/plan?id=${plan.id}`);
    }

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h3>Training plan</h3>
                <div className={style.mainImage}/>
            </div>
            <div className={style.content}>
                <div className={style.midHeader}>
                    <div style={{marginBottom:"1rem"}}>
                    <Link href="/athlete/training/trainings">
                        <Button
                            iconSrc='/thumbnails/arrow-back-outline.svg'
                            text='Return to plans'
                            borderValue='none'
                            backgroundColorValue='white'
                            isHoveringColor='#C7D7FE'
                            extraStyleType='color'
                            extraStyleValue='#8098F9'
                        />
                    </Link>
                    </div>
                    <h2>{plan.title}</h2>
                </div>
                <div className={style.details}>
                    <h5>Length: {plan.duration} weeks</h5>
                    <h5>Number of workouts: {plan.workouts.length}</h5>
                    <div className={style.description}>
                        <div>
                            <h5>Plan description</h5>
                            <p>
                                {plan.description}
                            </p>
                        </div>
                        <div>
                            <div className={style.bottomSection}>
                                <Link
                                    href={{
                                        pathname: `/athlete/marketplace/creator`,
                                        query: {creatorEmail: plan.creatorEmail, id: plan.id, goBack : `/athlete/training/plan`}
                                    }}
                                    style={{textDecoration: "none"}}
                                >
                                    <div className={style.userInfo}>
                                        <Image
                                            className={style.avatar}
                                            src='/avatar-svgrepo-com.svg'
                                            alt='dadas'
                                            width={30}
                                            height={30}
                                        />
                                        <div>
                                            <h5>Creator</h5>
                                            <p>{plan.creatorEmail}</p>
                                        </div>
                                    </div>
                                </Link>
                            </div>
                        </div>
                    </div>
                    <h5 style={{color: "#8098F9" , marginBottom:"1rem"}}>Workouts</h5>
                </div>
                <div className={style.bottom}>
                    <div className={style.trainings}>
                        {plan.workouts.map(workout => {
                            return (
                                <div style={{width: "30%"}} key={workout.id}>
                                    <TrainingPreview workout={workout}>
                                        <TrainingPlanPreview
                                            icon='/thumbnails/copy-outline.svg'
                                            backgroundColorValue='white'
                                            isHoveringColor='#D0D5DD'
                                            borderValue='none'
                                            workout={workout}
                                        />
                                    </TrainingPreview>
                                </div>
                            );
                        })}
                    </div>
                    <div className={style.rightBottom}>
                        <div className={style.rating}>
                            <p style={{marginTop: "1rem"}}>Rating</p>
                            {/*<Typography component="legend"/>*/}
                            <Rating
                                name='simple-controlled'
                                value={plan.ratingAvg}
                                disabled={plan.alreadyRated}
                                onChange={(event, newValue) => {
                                    ratePlan(newValue);
                                }}
                            />
                            <p style={{marginTop: "1rem"}}>{plan.ratingsApplied}
                                {plan.ratingsApplied === 1 ? ` review` : " reviews"}</p>
                            <h5>Rate plan</h5>
                        </div>
                        <div className={style.apply}>
                            <Button
                                iconSrc='/thumbnails/checkmark-outline.svg'
                                text='Apply plan'
                                borderValue='none'
                                backgroundColorValue='#8098F9'
                                isHoveringColor='#C7D7FE'
                                extraStyleType='color'
                                extraStyleValue='white'
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ApplyTrainingView;
