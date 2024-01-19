import style from "./left-pane.module.css";
import Image from "next/image";
import Button from "./button";
import Link from "next/link";
import {signOut, useSession} from "next-auth/react";
import {Avatar} from "@mui/material";
import {useState} from "react";
import {useRouter} from "next/router";
import {putter} from "../../lib/rest-api";

const routes = [
    "/athlete/dashboard",
    "/athlete/training",
    "/athlete/calendar",
    "/athlete/statistics",
    "/athlete/marketplace",
    "/athlete/settings",
];

const Sidebar = () => {
    const {data} = useSession();
    const router = useRouter();
    const [currentTab, setCurrentTab] = useState(router.asPath);

    async function registerAsTrainer() {
        if (data?.user.role !== "trainer") {
            await putter("users/trainer", {}, data.jwt);
            data.user.role = "trainer";
        }
    }

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
                {/* <div>
          <form className='d-flex' role='search'>
            <input
              className='form-control me-2'
              type='search'
              placeholder='Search'
              aria-label='Search...'
            />
          </form>
        </div> */}
                <div className={style.topButtons} role='group'>
                    <Link href='/athlete/dashboard'>
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
                    <Link href='/athlete/training/'>
                        <Button
                            iconSrc='/thumbnails/barbell-outline.svg'
                            text='Trainings'
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
                    <Link href='/athlete/calendar'>
                        <Button
                            iconSrc='/thumbnails/calendar-number-outline.svg'
                            text='Calendar'
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
                    <Link href='/athlete/statistics'>
                        <Button
                            iconSrc='/thumbnails/podium-outline.svg'
                            text='Statistics'
                            backgroundColorValue={
                                currentTab === routes[3] ? "#C7D7FE" : "white"
                            }
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={() => setCurrentTab(routes[3])}
                        />
                    </Link>
                    <Link href='/athlete/marketplace'>
                        <Button
                            iconSrc='/thumbnails/bag-outline.svg'
                            text='Marketplace'
                            backgroundColorValue={
                                currentTab === routes[4] ? "#C7D7FE" : "white"
                            }
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={() => setCurrentTab(routes[4])}
                        />
                    </Link>
                </div>
            </div>
            <div>
                <div className={style.bottomButtons}>
                    <Link href='/trainer/dashboard'>
                        <Button
                            iconSrc='/thumbnails/log-in-outline.svg'
                            text={
                                data?.user.role === "trainer"
                                    ? "Change to trainer view"
                                    : "Sign up as a Coach"
                            }
                            backgroundColorValue='white'
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={registerAsTrainer}
                        />
                    </Link>
                    <Link href='/athlete/settings'>
                        <Button
                            iconSrc='/thumbnails/settings-outline.svg'
                            text='Settings'
                            backgroundColorValue={
                                currentTab === routes[5] ? "#C7D7FE" : "white"
                            }
                            isHoveringColor='#C7D7FE'
                            borderValue='none'
                            extraStyleType='width'
                            extraStyleValue='100%'
                            onClick={() => setCurrentTab(routes[5])}
                        />
                    </Link>
                </div>
                <div className={style.bottomSection}>
                    <div className={style.userInfo}>
                        <Avatar src='/avatar.webp' className={"mr-4 mt-2"}/>
                        <div>
                            <h5>{data?.user.fullName}</h5>
                            <p>{data?.user.email}</p>
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

export default Sidebar;
