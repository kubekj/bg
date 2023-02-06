import style from "./buy-training-view.module.css";
import React from "react";
import Image from "next/image";
import Link from "next/link";
import { Rating, Typography } from "@mui/material";
import Button from "../../reusable/button";
import TrainingPreview from "../training/training-plans/training-preview";


const BuyTrainingView = ({plan}) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h3>Marketplace</h3>
        <div className={style.mainImage} />
      </div>
      <div className={style.content}>
        <div className={style.midHeader}>
          <Link href='/athlete/marketplace'>
            <Button
              iconSrc='/thumbnails/arrow-back-outline.svg'
              text='Browse more plans'
              borderValue='none'
              backgroundColorValue='white'
              isHoveringColor='#C7D7FE'
              extraStyleType='color'
              extraStyleValue='#8098F9'
            />
          </Link>
          <h2>{plan.title}</h2>
        </div>
        <div className={style.details}>
          <h5>Length: {plan.duration} weeks</h5>
          <h5>Number of workouts: {plan.noOfWorkouts}</h5>
          <div className={style.description}>
            <div>
              <h5>Plan description</h5>
              <p>
                {plan.description}
              </p>
            </div>
            <div>
              <div className={style.bottomSection}>
                  <Link href={{pathname: `/athlete/marketplace/creator`, query:{creatorEmail: plan.creatorEmail, id:plan.id}}} style={{textDecoration: "none"}}>
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
          <h5 style={{ color: "#8098F9" }}>Workouts</h5>
        </div>
        <div className={style.bottom}>
          <div className={style.trainings}>
            {plan.workouts.map(workout => {
              return(
                  <div style={{ width: "33%" }}>
                    <TrainingPreview workout={workout}/>
                  </div>
              );
            })}
          </div>
          <div className={style.rightBottom}>
            <div className={style.rating}>
              <p>Rating</p>
              <Typography component='legend' />
              <Rating
                name='simple-controlled'
                value={plan.ratingAvg}
                disabled={true}
              />
              <p>202 reviews</p>
              <b>{plan.ratingAvg}</b>
              <h5>Rate plan</h5>
            </div>
            <div className={style.apply}>
              <h5>{plan.price}</h5>
              <Button
                iconSrc='/thumbnails/checkmark-outline.svg'
                text='Buy plan'
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

export default BuyTrainingView;
