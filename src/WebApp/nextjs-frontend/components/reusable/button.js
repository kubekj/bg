import Image from "next/image";
import style from "./left-pane.module.css";
import {useState} from "react";

const Button = ({
                    iconSrc,
                    text,
                    extraStyleType,
                    extraStyleValue,
                    borderValue,
                    backgroundColorValue,
                    isHoveringColor,
                    onClick,
                    color
                }) => {
    const [isHovering, setIsHovering] = useState(false);

    const handleMouseEnter = () => {
        setIsHovering(true);
    };

    const handleMouseLeave = () => {
        setIsHovering(false);
    };

    return (
        <button
            type='button'
            className='btn btn-light'
            style={{
                color: `${color ? color : "black"}`,
                border: `${borderValue}`,
                textAlign: "left",
                backgroundColor: isHovering
                    ? `${isHoveringColor}`
                    : `${backgroundColorValue}`,
                [`${extraStyleType}`]: [`${extraStyleValue}`],
            }}
            onMouseEnter={handleMouseEnter}
            onMouseLeave={handleMouseLeave}
            onClick={onClick}
        >
            {iconSrc && text && (
                <Image
                    className={style.thumbNailsWithText}
                    src={iconSrc}
                    alt='dasda'
                    width={30}
                    height={30}
                />
            )}
            {iconSrc && !text && (
                <Image
                    className={style.thumbNails}
                    src={iconSrc}
                    alt='dasda'
                    width={30}
                    height={30}
                />
            )}
            {text}
        </button>
    );
};

export default Button;
