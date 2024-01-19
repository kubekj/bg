import Button from "./button";

const BottomButtonsSection = (
    {textL, textR, icoL, icoR, bgL, bgR, hovL, hovR, colorL, colorR}
) => {

    return (
        <div>
            <Button iconSrc={icoL}
                    text={textL}
                    borderValue="none"
                    backgroundColorValue={bgL}
                    isHoveringColor={hovL}
                    extraStyleType="color"
                    extraStyleValue={colorL}
            />
            <Button iconSrc={icoR}
                    text={textR}
                    borderValue="none"
                    backgroundColorValue={bgR}
                    isHoveringColor={hovR}
                    extraStyleType="color"
                    extraStyleValue={colorR}
            />
        </div>
    );
}

export default BottomButtonsSection;