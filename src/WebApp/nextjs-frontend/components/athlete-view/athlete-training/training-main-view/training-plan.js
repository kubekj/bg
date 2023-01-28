import style from "./training-plan.module.css";
import React from "react";
import Button from "../../../reusable-comps/button";
import Link from "next/link";


const sampleData = [
    {
        id: 1,
        trainingName: "Push",
        duration: "2 weeks",
        purchaseDate: "Jan 4, 2022",
        type: "Full-body",
        author: "Olivia Rye"
    },
    {
        id: 2,
        trainingName: "Pull",
        duration: "2 weeks",
        purchaseDate: "Jun 14, 2022",
        type: "Full-body",
        author: "Olivia Rye"
    },
    {
        id: 3,
        trainingName: "Split",
        duration: "4 weeks",
        purchaseDate: "Jan 4, 2022",
        type: "Full-body",
        author: "Olivia Rye"
    },
    {
        id: 4,
        trainingName: "Cardio",
        duration: "3 weeks",
        purchaseDate: "Jan 4, 2022",
        type: "Full-body",
        author: "Me"
    },
];




const TrainingPlan = () => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h5><b>Newest training plans</b></h5>
                    </div>
                    <div style={{marginBottom:"0.75rem"}}>
                        <Link href="/athlete-all-trainings">
                            <Button iconSrc="/thumbnails/copy-outline.svg" text="See all"
                                backgroundColorValue="white"
                                isHoveringColor="#D0D5DD"
                                extraStyleType="border"
                                extraStyleValue="1px solid #D0D5DD"
                            />
                        </Link>
                    </div>
                </div>
            </div>
            <div className={style.midSection}>
                <table className={style.tableOfTrainings}>
                    <thead className={style.tHead}>
                    <tr>
                        <th className={style.thRegular}>Training name</th>
                        <th className={style.thRegular}>Duration</th>
                        <th className={style.thRegular}>Purchase date</th>
                        <th className={style.thRegular}>Type</th>
                        <th className={style.thRegular}>Author</th>
                        <th className={style.thRegular}>Actions</th>
                    </tr>
                    </thead>
                    <tbody className={style.tBody}>
                    {
                        sampleData.map(training => {
                            return(
                              <tr key={training.id}>

                                      {/*style={{width:"30%",borderBottom: "1px solid #D0D5DD", paddingLeft:"2rem"}}*/}
                                  <td className={style.tdRegular}>
                                      <Link href="/athlete-apply-training">
                                      {training.trainingName}
                                      <p>dsadadada</p>
                                      </Link>
                                  </td>
                                  <td className={style.tdRegular}>{training.duration}</td>
                                  <td className={style.tdRegular}>{training.purchaseDate}</td>
                                  <td className={style.tdRegular}>{training.type}</td>
                                  <td className={style.tdRegular}>{training.author}</td>
                                  <td className={style.tdRegular}>
                                      <div>
                                        <Button iconSrc="/thumbnails/copy-outline.svg"
                                              backgroundColorValue="white"
                                              isHoveringColor="#D0D5DD"
                                              borderValue="none"
                                        />
                                        <Button iconSrc="/thumbnails/trash-bin-outline.svg"
                                              backgroundColorValue="white"
                                              isHoveringColor="#D0D5DD"
                                              borderValue="none"
                                        />
                                      </div>
                                  </td>
                              </tr>
                            );
                        })
                    }
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default TrainingPlan;