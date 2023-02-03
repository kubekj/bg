import style from "../athlete-marketplace/buy-training-view.module.css";
import React from "react";
import Image from "next/image";
import Link from "next/link";
import { Rating, Typography } from "@mui/material";
import Button from "../../reusable/button";
import TrainingPreview from "../athlete/training-plans/training-preview";

const BuyTrainingView = () => {
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
          <h2>Entry-level full body 4 weeks</h2>
        </div>
        <div className={style.details}>
          <h5>Length: 4 weeks</h5>
          <h5>Number of exercises: 6</h5>
          <div className={style.description}>
            <div>
              <h5>Plan description</h5>
              <p>
                I'm a Product Designer based in Melbourne, Australia. I
                specialise in UX/UI design, brand strategy, and Webflow
                development. I'm always striving to grow and learn something new
                and I don't take myself too seriously. I'm passionate about
                helping startups grow, improve their customer experience, and to
                raise venture capital through good design.
              </p>
            </div>
            <div>
              <div className={style.bottomSection}>
                <Link href='/creator-details'>
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
                      <p>adsasda@dsaasd.pl</p>
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
            <div style={{ width: "33%" }}>
              <Link
                href='/training-plan-details'
                style={{ textDecoration: "none" }}
              >
                <TrainingPreview backHref='/athlete-buy-training' />
              </Link>
            </div>
            <div style={{ width: "33%" }}>
              <TrainingPreview />
            </div>
            <div style={{ width: "33%" }}>
              <TrainingPreview />
            </div>
            <div style={{ width: "33%" }}>
              <TrainingPreview />
            </div>
            <div style={{ width: "33%" }}>
              <TrainingPreview />
            </div>
          </div>
          <div className={style.rightBottom}>
            <div className={style.rating}>
              <p>Rating</p>
              <Typography component='legend' />
              <Rating
                name='simple-controlled'
                value={5}
                // onChange={(event, newValue) => {
                //     setValue(newValue);
                // }}
              />
              <p>202 reviews</p>
              <b>4.02</b>
              <h5>Rate plan</h5>
            </div>
            <div className={style.apply}>
              <h5>120PLN</h5>
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
