import style from "./top-header.module.css";
import Button from "./button";
import Link from "next/link";

const TopHeader = ({title, text, href}) => {
    return (
        <div className={style.container}>
            <div className={style.top}>
                <div className={style.title}>
                    <div>
                        <h4>{title}</h4>
                        <p style={{fontSize: "14px"}}>{text}</p>
                    </div>
                </div>
                <div style={{paddingLeft: "33rem", marginTop: "1rem"}}>
                    <Link href={href}>
                        <Button
                            iconSrc='/thumbnails/close-outline.svg'
                            extraStyleType='marginLeft'
                            extraStyleValue='2rem'
                            backgroundColorValue='#F5F5F5'
                            isHoveringColor='#D0D5DD'
                            borderValue='none'
                        />
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default TopHeader;
