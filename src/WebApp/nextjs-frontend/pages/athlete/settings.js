import SettingsView from "../../components/settings/settings-view";
import Athlete from "../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../lib/rest-api";

export async function getServerSideProps(context) {
  const session = await getSession({ req: context.req });

  if (!session) {
    return {
      redirect: {
        destination: "/auth/login",
        permanent: false,
      },
    };
  }

  const options = {
    headers: {
      Authorization: `Bearer ${session.jwt}`,
    },
  };

  const user = await fetcher("users/details", options);

  return {
    props: {
      user: user,
    },
  };
}

const Settings = ({ user }) => {
  return <SettingsView user={user} />;
};

export default Settings;

Settings.layout = Athlete;
