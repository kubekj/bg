import style from "./left-pane.module.css"
import Image from "next/image";
import Button from "./button";
import Link from "next/link";

const DefaultLeftPane = () => {
    return (
        <div>
            <div className={style.header}>
                <Image className={style.logo} src="/bg-logo.svg" alt="adad" width={30} height={30} />
                <h3 style={{marginTop:"0.85rem"}}>BodyGuard menu</h3>
            </div>
            <div>
                <form className="d-flex" role="search">
                    <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search..." />
                </form>
            </div>
            <div className={style.topButtons} role="group">
                <Link href="/athlete-main-page">
                <Button iconSrc="/thumbnails/bar-chart-outline.svg" text="Dashboard"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
                </Link>
                <Link href="/athlete-training-main">
                <Button iconSrc="/thumbnails/barbell-outline.svg" text="Trainings"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
                </Link>
                <Link href="/athlete-calendar">
                <Button iconSrc="/thumbnails/calendar-number-outline.svg" text="Calendar"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
                </Link>
                <Button iconSrc="/thumbnails/podium-outline.svg" text="Statistics"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
                <Button iconSrc="/thumbnails/chatbox-ellipses-outline.svg" text="Messages"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
                <Button iconSrc="/thumbnails/bag-outline.svg" text="Marketplace"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
            </div>
            <div className={style.bottomButtons}>
                <Button iconSrc="/thumbnails/log-in-outline.svg" text="Sign up as a Coach"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
                <Button iconSrc="/thumbnails/settings-outline.svg" text="Settings"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                        borderValue="none"
                />
            </div>
            <div className={style.bottomSection}>
                <div className={style.userInfo}>
                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
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
    );
}

export default DefaultLeftPane;