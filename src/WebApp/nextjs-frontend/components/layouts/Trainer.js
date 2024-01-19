import React from "react";
import TrainerSidebar from "../trainer/sidebar";
import style from "../../styles/athlete-main-page.module.css";

function Trainer({children}) {
    return (
        <>
            <div className={style.container}>
                <div style={{borderRight: "1px solid #D0D5DD", width: "325px"}}>
                    <TrainerSidebar/>
                </div>
                {children}
            </div>
        </>
    );
}

export default Trainer;
