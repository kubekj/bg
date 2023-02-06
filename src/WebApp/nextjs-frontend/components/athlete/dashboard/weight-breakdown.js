import style from "./weight-breakdown.module.css";
import Image from "next/image";
import React from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Bar } from "react-chartjs-2";
import faker from "faker";
import Button from "../../reusable/button";
import Link from "next/link";

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);



const WeightBreakdown = ({weightBreakdown}) => {
   const options = {
    responsive: true,
    plugins: {
      legend: {
        display: false,
        position: "bottom",
      },
      title: {
        display: false,
        text: "Chart.js Bar Chart",
      },
    },
    scales: {
      y: {
        title: {
          display: true,
          text: "Kilograms",
        },
      },
      x: {
        title: {
          display: true,
          text: "Month",
        },
        grid: {
          display: false,
        },
      },
    },
  };


  let labels = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];

  let apilabels = Object.keys(weightBreakdown);

  const data = {
    labels,
    datasets: [
      {
        label: "Body weight",
        data: apilabels.map(month => weightBreakdown[month]),
        backgroundColor: "#C7D7FE",
      },
    ],
  };

  console.log(weightBreakdown);
  console.log(apilabels);
  return (
    <div className={style.container}>
      <div className={style.header}>
        <div className={style.info}>
          <Image
            className={style.mainIcon}
            src='/thumbnails/scale-outline.svg'
            alt='dadas'
            width={30}
            height={30}
          />
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
        <Link href='/athlete/statistics'>
          <Button
            iconSrc='/thumbnails/podium-outline.svg'
            text='View all statistics'
            extraStyleType='border'
            extraStyleValue='1px solid #D0D5DD'
            backgroundColorValue='white'
            isHoveringColor='#D0D5DD'
          />
        </Link>
      </div>
    </div>
  );
};

export default WeightBreakdown;
