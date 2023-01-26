import style from "../athlete-marketplace/creator-view.module.css"
import React from "react";
import Image from "next/image";
import Link from "next/link";
import Button from "../reusable-comps/button";
import TrainingPreview from "../athlete-training/training-plans/training-preview";

const CreatorView = () => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h3>Marketplace</h3>
                <div className={style.mainImage}/>
            </div>
            <div className={style.content}>
                <div className={style.midHeader}>
                    <Link href="/athlete-marketplace">
                        <Button iconSrc="/thumbnails/arrow-back-outline.svg"
                                text="Browse more plans"
                                borderValue="none"
                                backgroundColorValue="white"
                                isHoveringColor="#C7D7FE"
                                extraStyleType="color"
                                extraStyleValue="#8098F9"
                        />
                    </Link>
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
                <div className={style.details}>
                    <div className={style.description}>
                        <div>
                            <h5>About me</h5>
                            <p>I'm a Product Designer based in Melbourne, Australia. I specialise in UX/UI design, brand
                                strategy, and Webflow development. I'm always striving to grow and learn something new
                                and I don't take myself too seriously.
                                I'm passionate about helping startups grow, improve their customer experience, and to
                                raise venture capital through good design.</p>
                        </div>

                    </div>
                    <h5 style={{color: "#8098F9"}}>Workouts</h5>
                </div>
                <div className={style.bottom}>
                    <div className={style.trainings}>
                        <div>
                            <Link href="/training-plan-details" style={{textDecoration:"none"}}>
                                <TrainingPreview backHref="/athlete-buy-training"/>
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
                </div>
            </div>
        </div>
    );
}

export default CreatorView;