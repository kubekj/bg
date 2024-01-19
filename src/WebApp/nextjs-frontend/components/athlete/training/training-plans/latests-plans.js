import Link from "next/link";
import React from "react";
import Button from "../../../reusable/button";

function LatestPlans({plans}) {
    return (
        <>
            <div className='relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-md rounded-xl'>
                <div className='rounded-t py-3 border-0'>
                    <div className='flex flex-wrap items-center'>
                        <div className='relative w-full px-4 max-w-full flex-grow flex-1'>
                            <h3 className='font-semi-bold text-base text-blueGray-700 my-auto'>
                                Latest training plans
                            </h3>
                        </div>
                        <div className='relative w-full px-4 max-w-full flex-grow flex-1 text-right'>
                            <Link href='/athlete/training/trainings'>
                                <Button
                                    iconSrc='/thumbnails/copy-outline.svg'
                                    text='See all'
                                    backgroundColorValue='white'
                                    isHoveringColor='#D0D5DD'
                                    extraStyleType='border'
                                    extraStyleValue='1px solid #D0D5DD'
                                />
                            </Link>
                        </div>
                    </div>
                </div>
                <div className='block w-full overflow-x-auto'>
                    <table className='items-center w-full bg-transparent border-collapse'>
                        <thead className='thead-light bg-indigo-400 text-white'>
                        <tr>
                            <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Name
                            </th>
                            <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Duration
                            </th>
                            <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                No. of workouts
                            </th>
                            <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Purchase Date
                            </th>
                            <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Skill Level
                            </th>
                            <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Author
                            </th>
                        </tr>
                        </thead>
                        <tbody className='divide-y divide-gray-200'>
                        {plans && plans.length !== 0 ? (
                            plans.map((plan) => {
                                return (
                                    <tr key={plan.id}>
                                        <td className='text-xs p-4'>{plan.title}</td>
                                        <td className='text-xs p-4'>{plan.duration}</td>
                                        <td className='text-xs p-4'>{plan.noOfWorkouts}</td>
                                        <td className='text-xs p-4'>{plan.title}</td>
                                        <td className='text-xs p-4'>{plan.skillLevel}</td>
                                        <td className='text-xs p-4'>{plan.creatorEmail}</td>
                                    </tr>
                                );
                            })
                        ) : (
                            <React.Fragment/>
                        )}
                        </tbody>
                    </table>
                </div>
            </div>
        </>
    );
}

export default LatestPlans;
