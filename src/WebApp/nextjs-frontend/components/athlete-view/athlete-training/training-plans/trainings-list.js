import style from "./trainings-list.module.css";
import Link from "next/link";
import Button from "../../../reusable-comps/button";
import React from "react";


const TrainingsList = ({plans}) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h2>Training plans</h2>
                <p>Manage all your training plans here.</p>
            </div>
            <div className={style.tableContainer}>
                <div className={style.header}>
                    <div className={style.info}>
                        <div>
                            <h4><b>Plans</b></h4>
                        </div>
                        <div style={{marginBottom: "0.75rem"}}>
                            <Link href="/add-new-training">
                                <Button iconSrc="/thumbnails/add-outline.svg" text="Add training"
                                        backgroundColorValue="#8098F9"
                                        borderValue="none"
                                        isHoveringColor="#C7D7FE"
                                        extraStyleType="color"
                                        extraStyleValue="white"
                                />
                            </Link>
                        </div>
                    </div>
                </div>
                <div>
                    <table className={style.tableOfTrainings}>
                        <thead className={style.tHead}>
                        <tr>
                            <th className={style.thRegular}>Name</th>
                            <th className={style.thRegular}>Weeks</th>
                            <th className={style.thRegular}>Duration</th>
                            <th className={style.thRegular}>Purchase date</th>
                            <th className={style.thRegular}>Type</th>
                            <th className={style.thRegular}>Actions</th>
                        </tr>
                        </thead>
                        <tbody className={style.tBody}>
                        {plans.map(plan => {
                            return (
                                <tr key={plan.title}>
                                    <td className={style.tdRegular}>{plan.title}</td>
                                    <td className={style.tdRegular}>{plan.duration}</td>
                                    <td className={style.tdRegular}>{plan.creatorEmail}</td>
                                    <td className={style.tdRegular}>
                                        <div className={style.infoProgress} style={{backgroundColor: "#F9F5FF",
                                            color: "#98B3DB"
                                        }}>{plan.skillLevel}
                                        </div>
                                    </td>
                                    <td className={style.tdRegular}>{plan.creatorEmail}</td>
                                    <td className={style.tdRegular} style={{padding:"0"}}>
                                        <Button iconSrc="/thumbnails/copy-outline.svg"
                                                backgroundColorValue="white"
                                                isHoveringColor="#D0D5DD"
                                                borderValue="none"
                                        />
                                        <Button iconSrc="/thumbnails/modify.svg"
                                                backgroundColorValue="white"
                                                isHoveringColor="#D0D5DD"
                                                borderValue="none"
                                        />
                                        <Button iconSrc="/thumbnails/trash-bin-outline.svg"
                                                backgroundColorValue="white"
                                                isHoveringColor="#D0D5DD"
                                                borderValue="none"
                                        />
                                    </td>
                                </tr>
                            );
                        })}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default TrainingsList;