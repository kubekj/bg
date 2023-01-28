import style from "../reusable-comps/left-pane.module.css"
import Image from "next/image";
import Button from "../reusable-comps/button";
import Link from "next/link";

const TrainerLeftPane = () => {
    return (
        <div className={style.container}>
            <div>
                <div className={style.header}>
                    <Image className={style.logo} src="/bg-logo.svg" alt="adad" width={30} height={30}/>
                    <h3 style={{marginTop: "0.85rem"}}>BodyGuard menu</h3>
                </div>
                <div>
                    <form className="d-flex" role="search">
                        <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search..."/>
                    </form>
                </div>
                <div className={style.topButtons} role="group">
                    <Link href="/trainer-dashboard">
                        <Button iconSrc="/thumbnails/bar-chart-outline.svg" text="Dashboard"
                                backgroundColorValue="white"
                                isHoveringColor="#D0D5DD"
                                borderValue="none"
                                extraStyleType="width"
                                extraStyleValue="100%"
                        />
                    </Link>
                    <Link href="/athlete-training-main">
                        <Button iconSrc="/thumbnails/layers-outline.svg" text="Plans"
                                backgroundColorValue="white"
                                isHoveringColor="#D0D5DD"
                                borderValue="none"
                                extraStyleType="width"
                                extraStyleValue="100%"
                        />
                    </Link>
                </div>
            </div>
            <div>
                <div className={style.bottomButtons}>
                    <Link href="/athlete-main-page">
                        <Button iconSrc="/thumbnails/log-in-outline.svg" text="Change to athlete view"
                                backgroundColorValue="white"
                                isHoveringColor="#D0D5DD"
                                borderValue="none"
                                extraStyleType="width"
                                extraStyleValue="100%"
                        />
                    </Link>
                    <Link href="/settings">
                        <Button iconSrc="/thumbnails/settings-outline.svg" text="Settings"
                                backgroundColorValue="white"
                                isHoveringColor="#D0D5DD"
                                borderValue="none"
                                extraStyleType="width"
                                extraStyleValue="100%"
                        />
                    </Link>
                </div>
                <div className={style.bottomSection}>
                    <div className={style.userInfo}>
                        <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30}
                               height={30}/>
                        <div>
                            <h5>John Doe</h5>
                            <p>john.doe@gmail.com</p>
                        </div>
                    </div>
                    <Button iconSrc="/thumbnails/log-out-outline.svg" extraStyleType="marginLeft" extraStyleValue="2rem"
                            backgroundColorValue="white"
                            isHoveringColor="#D0D5DD"
                            borderValue="none"
                    />
                </div>
            </div>
        </div>
    );
}

export default TrainerLeftPane;