import style from "./hours-trained.module.css";
import Image from "next/image";
import Button from "../button";
import React from 'react';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import { Doughnut } from 'react-chartjs-2';

ChartJS.register(ArcElement, Tooltip, Legend);


export const options = {
    responsive: true,
    plugins: {
        legend: {
            display: false,
            position: 'bottom',
        },
        title: {
            display: false,
            text: 'Chart.js Bar Chart',
        },
    }
};

export const data = {
    labels: ['Red', 'Blue'],
    datasets: [
        {
            label: '# of Votes',
            data: [33, 19],
            backgroundColor: [
                "#8098F9",
                'rgba(240, 240, 240, 1)'
            ],
            borderColor: [
                "#8098F9",
                'rgba(240, 240, 240, 1)'
            ],
            borderWidth: 1,
        },
    ],
};

const HoursTrained = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h4>Hours trained</h4>
                        <p>You've been doing well</p>
                    </div>
                </div>
            </div>
            <div className={style.midSection}>
                <Doughnut options={options} data={data} />
                <div className={style.underDonut}>
                    <h5>You've almost reached your goal</h5>
                    <p>Keep up the great work</p>
                </div>
            </div>
            <div className={style.bottomSection}>
                <Button iconSrc="/thumbnails/thunder.svg" text="View all statistics" extraStyleType="border" extraStyleValue="1px solid #D0D5DD"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                />
                <Button iconSrc="/thumbnails/square-add.svg" text="Add goals"
                        backgroundColorValue="#8098F9"
                        isHoveringColor="#C7D7FE"
                        borderValue="none"
                        extraStyleType="color" extraStyleValue="white"
                />
                {/*<button type="button" className="btn btn-light"*/}
                {/*        style={{border: "none", textAlign: "left", backgroundColor: '#D0D5DD',marginRight: "1rem", color:"white"}}*/}
                {/*>*/}
                {/*    <Image className={style.thumbNails} src="/thumbnails/square-add.svg" alt="dasda" width={30}*/}
                {/*           height={30}/>*/}
                {/*    Add goalsaa*/}
                {/*</button>*/}
            </div>
        </div>
    );
}

export default HoursTrained;