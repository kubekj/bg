import style from "./hours-trained.module.css";
import Button from "../../reusable/button";
import React from "react";
import {ArcElement, Chart as ChartJS, Legend, Tooltip} from "chart.js";
import {Doughnut} from "react-chartjs-2";
import Link from "next/link";
import GoalModal from "../modals/goal-modal";

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
    const toDo = doneTrainings["item2"] - doneTrainings["item1"];
    const data = {
        labels: ["Done", "To do"],
        datasets: [
            {
                label: "Trainings",
                data: [doneTrainings["item1"], toDo],
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
                        <h4>Trainings done this month</h4>
                        <p>Track your progress down below</p>
                    </div>
                </div>
            </div>
            <div className={style.midSection}>
                {doneTrainings["item2"] ?
                    <React.Fragment>
                        <h5 className={style.statTitle}>Trainings
                            done: {doneTrainings["item1"]}/{doneTrainings["item2"]}</h5>
                        <Doughnut options={options} data={data}/>
                    </React.Fragment>
                    :
                    <h5 className={style.statTitle}>No trainings goal set</h5>
                }
            </div>
            <div className={style.bottomSection}>
                <div>
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
                </div>
                <div style={{marginLeft: "2rem"}}>
                    <GoalModal
                        icon='/thumbnails/square-add.svg'
                        backgroundColorValue='#8098F9'
                        isHoveringColor='#C7D7FE'
                        borderValue='none'
                        extraStyleType='color'
                        extraStyleValue='white'
                        goal={doneTrainings["item2"]}
                    />
                </div>
            </div>
        </div>
    );
};

export default HoursTrained;
