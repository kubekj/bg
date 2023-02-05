import style from "../reusable/left-pane.module.css";
import Image from "next/image";
import Button from "../reusable/button";
import Link from "next/link";
import { useSession } from "next-auth/react";
import { Avatar } from "@mui/material";

const TrainerSidebar = () => {
  const { data } = useSession();

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
              backgroundColorValue='white'
              isHoveringColor='#D0D5DD'
              borderValue='none'
              extraStyleType='width'
              extraStyleValue='100%'
            />
          </Link>
          <Link href='/trainer/plans'>
            <Button
              iconSrc='/thumbnails/layers-outline.svg'
              text='Plans'
              backgroundColorValue='white'
              isHoveringColor='#D0D5DD'
              borderValue='none'
              extraStyleType='width'
              extraStyleValue='100%'
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
              isHoveringColor='#D0D5DD'
              borderValue='none'
              extraStyleType='width'
              extraStyleValue='100%'
            />
          </Link>
          <Link href='/trainer/settings'>
            <Button
              iconSrc='/thumbnails/settings-outline.svg'
              text='Settings'
              backgroundColorValue='white'
              isHoveringColor='#D0D5DD'
              borderValue='none'
              extraStyleType='width'
              extraStyleValue='100%'
            />
          </Link>
        </div>
        <div className={style.bottomSection}>
          <div className={style.userInfo}>
            <div className={style.userInfo}>
              <Avatar src='/avatar.webp' className={"mr-4 mt-2"} />
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
            isHoveringColor='#D0D5DD'
            borderValue='none'
          />
        </div>
      </div>
    </div>
  );
};

export default TrainerSidebar;
