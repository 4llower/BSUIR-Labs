from setuptools import setup, find_packages

setup(name="serialize_utility",
      packages=['packages', 'packages/factory', 'packages/serializers'],
      scripts=['bin/serialize'])
