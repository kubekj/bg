import style from "./hours-trained.module.css";
import Button from "../../reusable/button";
import React from "react";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Doughnut } from "react-chartjs-2";
import Link from "next/link";

ChartJS.register(ArcElement, Tooltip, Legend);



const HoursTrained = ({doneTrainings}) => {
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
  };

  const data = {
    labels: ["Red", "Blue"],
    datasets: [
      {
        label: "# of Votes",
        data: [doneTrainings["item1"], doneTrainings["item2"]],
        backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderWidth: 1,
      },
    ],
  };


  return (
    <div className={style.container}>
      <div className={style.header}>
        <div className={style.info}>
          <div>
            <h4>Trainings done</h4>
            <p>Track your progress down below</p>
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
        <Link href='/athlete/statistics'>
          <Button
            iconSrc='/thumbnails/thunder.svg'
            text='View all statistics'
            extraStyleType='border'
            extraStyleValue='1px solid #D0D5DD'
            backgroundColorValue='white'
            isHoveringColor='#D0D5DD'
          />
        </Link>
        <Button
          iconSrc='/thumbnails/square-add.svg'
          text='Add goals'
          backgroundColorValue='#8098F9'
          isHoveringColor='#C7D7FE'
          borderValue='none'
          extraStyleType='color'
          extraStyleValue='white'
        />
      </div>
    </div>
  );
};

export default HoursTrained;
