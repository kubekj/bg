import style from "./exercise-list.module.css";
import Link from "next/link";
import Button from "../../../reusable-comps/button";
import React from "react";

const ExercisesList = () => {

    const sampleData = [
        {
            id: 1,
            firstName: "John",
            lastName: "Doe",
            email: "john.doe@gmail.com",
            duration: "2 weeks",
            isActive: true,
            purchaseDate: "Jan 4, 2022",
            type: "Full-body",
            author: "Olivia Rye"
        },
        {
            id: 2,
            firstName: "John",
            lastName: "Smith",
            email: "john.doe@gmail.com",
            duration: "2 weeks",
            isActive: true,
            purchaseDate: "Jun 14, 2022",
            type: "Full-body",
            author: "Olivia Rye"
        },
        {
            id: 3,
            firstName: "John",
            lastName: "Doe",
            email: "john.doe@gmail.com",
            duration: "4 weeks",
            isActive: false,
            purchaseDate: "Jan 4, 2022",
            type: "Full-body",
            author: "Olivia Rye"
        },
        {
            id: 4,
            firstName: "Jane",
            lastName: "Doe",
            email: "john.doe@gmail.com",
            duration: "3 weeks",
            isActive: false,
            purchaseDate: "Jan 4, 2022",
            type: "Full-body",
            author: "Me"
        },
    ];

    return(
        <div className={style.container}>
            <div className={style.header}>
                <h2>Exercises</h2>
                <p>Manage your exercises here.</p>
            </div>
            <div className={style.tableContainer}>
                <div className={style.header}>
                    <div className={style.info}>
                        <div>
                            <h4><b>Exercise</b></h4>
                        </div>
                        <div style={{marginLeft: "73rem", marginBottom:"0.75rem"}}>
                            <Link href="/add-new-exercise">
                                <Button iconSrc="/thumbnails/add-outline.svg" text="Add new"
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
                            <th className={style.thRegular}>Body Part</th>
                            <th className={style.thRegular}>Category</th>
                            <th className={style.thRegular}>Action</th>
                        </tr>
                        </thead>
                        <tbody className={style.tBody}>
                        {
                            sampleData.map(training => {
                                return(

                                    <tr key={training.id}>
                                        <td className={style.tdRegular}>
                                            {training.lastName}
                                        </td>
                                        <td className={style.tdRegular}>
                                            <div className={style.infoProgress}
                                                 style={{backgroundColor: sampleData.map(a => a.isActive) ? "#ECFDF3" : "#FEF3F2",
                                                     color: sampleData.map(a => a.isActive) ? "#027A48" : "#B42318"
                                                 }}
                                            >
                                                Status
                                            </div>
                                        </td>
                                        <td className={style.tdRegular}>{training.duration}</td>
                                        <td className={style.tdRegular}>
                                            <div>
                                                <Link href="/edit-exercise">
                                                <Button iconSrc="/thumbnails/modify.svg" extraStyleType="marginLeft" extraStyleValue="2rem"
                                                        backgroundColorValue="white"
                                                        isHoveringColor="#D0D5DD"
                                                        borderValue="none"
                                                />
                                                </Link>
                                                <Button iconSrc="/thumbnails/trash-bin-outline.svg" extraStyleType="marginLeft" extraStyleValue="2rem"
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
        </div>
    );
}

export default ExercisesList;