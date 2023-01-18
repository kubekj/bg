import style from "./weight-breakdown.module.css";
import Image from "next/image";
import React, {useState} from 'react';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';
import { Bar } from 'react-chartjs-2';
import faker from 'faker';
import Button from "../button";

ChartJS.register(
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend
);

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
    },
    scales:{
        y: {
            title: {
                display: true,
                text: 'Kilograms',
            }
        },
        x: {
            title: {
                display: true,
                text: 'Month',
            },
            grid: {
                display: false,
            }
        }
    }
};

const labels = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

export const data = {
    labels,
    datasets: [
        {
            label: 'Dataset 2',
            data: labels.map(() => faker.datatype.number({ min: 0, max: 150 })),
            backgroundColor: "#C7D7FE",
        },
    ],
};

const WeightBreakdown = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <Image className={style.mainIcon} src="/thumbnails/scale-outline.svg" alt="dadas" width={30} height={30} />
                    <div>
                        <h4>Weight breakdown</h4>
                        <p>Keep track of your weight stats</p>
                    </div>
                </div>
            </div>
            <div className={style.midSection}>
                <Bar options={options} data={data} />
            </div>
            <div className={style.bottomSection}>
                <Button iconSrc="/thumbnails/podium-outline.svg" text="View all statistics" extraStyleType="border" extraStyleValue="1px solid #D0D5DD"
                        backgroundColorValue="white"
                        isHoveringColor="#D0D5DD"
                />
            </div>
        </div>
    );
}

export default WeightBreakdown;