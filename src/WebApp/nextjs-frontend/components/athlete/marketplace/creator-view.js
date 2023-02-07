import style from "../marketplace/creator-view.module.css";
import React from "react";
import Image from "next/image";
import Link from "next/link";
import Button from "../../reusable/button";
import TrainingPreview from "../training/training-plans/training-preview";
import { useRouter } from "next/router";

const CreatorView = ({ creatorDetails, recentPlans }) => {
  const router = useRouter();

  function getId() {
    return router.query.id;
  }

  function getBack(){
    return router.query.goBack;
  }

  return (
    <div className={style.container}>
      <div className={style.header}>
        <h3>Creator</h3>
        <div className={style.mainImage} />
      </div>
      <div className={style.content}>
        <div className={style.midHeader}>
          <div style={{marginBottom:"1rem"}}>
          <Link
            href={{
              pathname: `${getBack()}`,
              query: { id: getId() },
            }}
            style={{ textDecoration: "none" }}
          >
            <Button
              iconSrc='/thumbnails/arrow-back-outline.svg'
              text='Go back'
              borderValue='none'
              backgroundColorValue='white'
              isHoveringColor='#C7D7FE'
              extraStyleType='color'
              extraStyleValue='#8098F9'
            />
          </Link>
          </div>
        </div>
        <div>
          <div className={style.bottomSection}>
            <div className={style.userInfo}>
              <Image
                className={style.avatar}
                src='/avatar-svgrepo-com.svg'
                alt='dadas'
                width={30}
                height={30}
              />
              <div>
                <h5>
                  {creatorDetails.firstName} {creatorDetails.lastName}
                </h5>
                <p>{creatorDetails.trainerEmail}</p>
              </div>
            </div>
          </div>
        </div>
        <div className={style.details}>
          <div className={style.description}>
            <div>
              <h5>About me</h5>
              <p>{creatorDetails.description}</p>
            </div>
          </div>
          <h5 style={{ color: "#8098F9" }}>Workouts</h5>
        </div>
        <div className={style.bottom}>
          <div className={style.trainings}>
            {recentPlans.workouts.map((workout) => {
              return (
                  <div style={{ width: "30%" }} key={workout.id}>
                    {/*<TrainingPreview workout={workout} />*/}
                    <TrainingPreview  />
                  </div>
              );
            })}
          </div>
        </div>
      </div>
    </div>
  );
};

export default CreatorView;
