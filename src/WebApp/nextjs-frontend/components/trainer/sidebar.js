import style from "../reusable/left-pane.module.css";
import Image from "next/image";
import Button from "../reusable/button";
import Link from "next/link";
import {signOut, useSession} from "next-auth/react";
import {Avatar} from "@mui/material";
import {useRouter} from "next/router";
import {useState} from "react";

const routes = [
    "/trainer/dashboard",
    "/trainer/plans",
    "/trainer/settings"
];

const TrainerSidebar = () => {
    const {data} = useSession();
    const router = useRouter();
    const [currentTab, setCurrentTab] = useState(router.asPath);

    return (
        <div className={style.container}>
            <div>
                <div className={style.header}>
                    <Image
                        className={style.logo}
                        src='/bg-logo.svg'
                        alt='adad'
                        width={30}
                        height={30}
                    />
                </div>
                <div className={style.topButtons} role='group'>
                    <Link href='/trainer/dashboard'>
                        <Button
                            iconSrc='/thumbnails/bar-chart-outline.svg'
                            text='Dashboard'
                            backgroundColorValue={
                                currentTab === routes[0] ? "#C7D7FE" : "white"
                            }
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={() => setCurrentTab(routes[0])}
                        />
                    </Link>
                    <Link href='/trainer/plans'>
                        <Button
                            iconSrc='/thumbnails/layers-outline.svg'
                            text='Plans'
                            backgroundColorValue={
                                currentTab === routes[1] ? "#C7D7FE" : "white"
                            }
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={() => setCurrentTab(routes[1])}
                        />
                    </Link>
                </div>
            </div>
            <div>
                <div className={style.bottomButtons}>
                    <Link href='/athlete/dashboard'>
                        <Button
                            iconSrc='/thumbnails/log-in-outline.svg'
                            text='Change to athlete view'
                            backgroundColorValue='white'
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                        />
                    </Link>
                    <Link href='/trainer/settings'>
                        <Button
                            iconSrc='/thumbnails/settings-outline.svg'
                            text='Settings'
                            backgroundColorValue={
                                currentTab === routes[2] ? "#C7D7FE" : "white"
                            }
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={() => setCurrentTab(routes[2])}
                        />
                    </Link>
                </div>
                <div className={style.bottomSection}>
                    <div className={style.userInfo}>
                        <div className={style.userInfo}>
                            <Avatar src='/avatar.webp' className={"mr-4 mt-2"}/>
                            <div>
                                <h5>{data?.user.fullName}</h5>
                                <p>{data?.user.email}</p>
                            </div>
                        </div>
                    </div>
                    <Button
                        iconSrc='/thumbnails/log-out-outline.svg'
                        extraStyleType='marginLeft'
                        extraStyleValue='2rem'
                        backgroundColorValue='white'
                        isHoveringColor='#f75e63'
                        borderValue='none'
                        onClick={() => {
                            signOut();
                            router.push("/auth/login");
                        }}
                    />
                </div>
            </div>
        </div>
    );
};

export default TrainerSidebar;
