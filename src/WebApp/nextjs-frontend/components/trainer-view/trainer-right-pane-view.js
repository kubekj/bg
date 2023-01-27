import style from "../trainer-view/trainer-right-pane-view.module.css";
import React from 'react';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';
import { Line } from 'react-chartjs-2';
import faker from 'faker';
import Image from "next/image";

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
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
                text: '$',
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

const labels = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

export const data = {
    labels,
    datasets: [
        {
            label: 'Dataset 1',
            data: labels.map(() => faker.datatype.number({ min: 0, max: 10000 })),
            borderColor: '#C7D7FE',
            backgroundColor: '#C7D7FE',
        },
        {
            label: 'Dataset 2',
            data: labels.map(() => faker.datatype.number({ min: 0, max: 10000 })),
            borderColor: 'rgba(53, 162, 235, 0.5)',
            backgroundColor: 'rgba(53, 162, 235, 0.5)',
        },
    ],
};


const TrainerRightPaneView = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <h4>Earnings overtime</h4>
                <p style={{marginBottom:"2rem"}}>Compare earnings overtime</p>
            </div>
            <Line options={options} data={data} />
            <div className={style.overview}>
                <h5 style={{marginBottom:"1rem"}}>Activity</h5>
                <div style={{borderTop: "1px solid #D0D5DD", marginBottom: "1rem"}}/>
                    <div className={style.userInfo}>
                        <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
                        <div>
                            <h5>John Doe</h5>
                            <p>john.doe@gmail.com</p>
                        </div>
                    </div>
                <div className={style.userInfo}>
                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
                    <div>
                        <h5>John Doe</h5>
                        <p>john.doe@gmail.com</p>
                    </div>
                </div>
                <div className={style.userInfo}>
                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
                    <div>
                        <h5>John Doe</h5>
                        <p>john.doe@gmail.com</p>
                    </div>
                </div>
                <div className={style.userInfo}>
                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
                    <div>
                        <h5>John Doe</h5>
                        <p>john.doe@gmail.com</p>
                    </div>
                </div>
                <div className={style.userInfo}>
                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
                    <div>
                        <h5>John Doe</h5>
                        <p>john.doe@gmail.com</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TrainerRightPaneView;